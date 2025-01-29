using System.Collections;
using System.Collections.Generic;
using ntdotjsx.Gameplay;
using UnityEngine;
using static ntdotjsx.Core.Simulation;

namespace ntdotjsx.Mechanics
{
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public PatrolPath path;
        public AudioClip ouch;

        internal PatrolPath.Mover mover;
        internal AnimationController control;
        internal Collider2D _collider;
        public bool isDead { get; private set; } = false;
        internal AudioSource _audio;
        SpriteRenderer spriteRenderer;

        public Bounds Bounds => _collider.bounds;

        void Awake()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                var ev = Schedule<PlayerEnemyCollision>();
                ev.player = player;
                ev.enemy = this;
                // player.Bounce(7);
            }
        }

        // ฟังก์ชันเมื่อศัตรูตาย
        public void Defeat()
        {
            if (isDead) return; // ถ้าศัตรูตายแล้วไม่ต้องทำอะไรซ้ำ
            isDead = true;
            CheckVictory(); // เช็คว่าเกมชนะหรือยัง
        }

        // ฟังก์ชันเช็คว่าเกมชนะหรือยัง
        public static void CheckVictory()
        {
            EnemyController[] enemies = FindObjectsOfType<EnemyController>(); // ค้นหาศัตรูทั้งหมดในฉาก
            bool allEnemiesDefeated = true;

            foreach (var enemy in enemies)
            {
                // ถ้ายังมีศัตรูที่ยังไม่ตาย
                if (!enemy.isDead)
                {
                    allEnemiesDefeated = false;
                    break; // ถ้ามีศัตรูที่ยังไม่ตายให้หยุดตรวจสอบ
                }
            }

            if (allEnemiesDefeated)
            {
                Debug.Log("Victory!");
                OnVictory(); // ถ้าศัตรูทั้งหมดตายแล้ว
            }
        }

        // 👌 Victory แล้ว
        private static void OnVictory()
        {
            Debug.Log("You have won the game!");
            var ev = Schedule<PlayerVictory>();
        }

        void Update()
        {
            if (path != null && !isDead) // ถ้าศัตรูตายแล้วจะไม่เคลื่อนที่
            {
                if (mover == null) mover = path.CreateMover(control.maxSpeed * 0.5f);
                control.move.x = Mathf.Clamp(mover.Position.x - transform.position.x, -1, 1);
            }
        }
    }
}
