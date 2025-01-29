using System;
using ntdotjsx.Gameplay;
using UnityEngine;
using static ntdotjsx.Core.Simulation;

namespace ntdotjsx.Mechanics
{
    public class Health : MonoBehaviour
    {
        public int maxHP = 4;  // ตั้งค่าให้ผู้เล่นมี 4 ชีวิต
        public bool IsAlive => currentHP > 0;

        private int currentHP;
        public int CurrentHP => currentHP;

        // เพิ่ม HP ขึ้นโดยไม่เกิน maxHP
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        // ลด HP
        public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            Debug.Log($"Health Decremented: {currentHP} HP left");
            if (currentHP == 0)
            {
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }

        // เมื่อผู้เล่นตาย ต้องลด HP จนเหลือ 0
        public void Die()
        {
            // ลด HP ให้ถึง 0 โดยใช้ Decrement()
            while (currentHP > 0) 
            {
                Decrement();
            }
            // หลังจากที่ตายแล้ว รีเซ็ต HP ให้กลับไปเต็ม
            currentHP = maxHP;  // รีเซ็ตให้กลับเป็น maxHP
            Debug.Log("Player has respawned with full health!");
        }

        void Awake()
        {
            currentHP = maxHP; // กำหนดค่าเริ่มต้นให้ HP เป็น maxHP
        }
    }
}
