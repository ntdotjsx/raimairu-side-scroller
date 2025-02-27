using System;
using ntdotjsx.Gameplay;
using UnityEngine;
using static ntdotjsx.Core.Simulation;

namespace ntdotjsx.Mechanics
{
    public class Health : MonoBehaviour
    {
        public int maxHP = 3;  // กำหนดให้ผู้เล่นมี 3 ชีวิต
        private int currentHP;

        // ความสามารถในการเช็คว่า Alive หรือไม่
        public bool IsAlive => currentHP > 0;
        public int CurrentHP => currentHP;

        // เพิ่มพลังชีวิต
        public void Increment(int amount = 1) // สามารถกำหนดค่าการเพิ่มเลือดได้
        {
            currentHP = Mathf.Clamp(currentHP + amount, 0, maxHP);
        }


        // ลดพลังชีวิต
        public void Decrement(int amount = 1)
        {
            currentHP = Mathf.Clamp(currentHP - amount, 0, maxHP);
            Debug.Log($"Health Decremented: {currentHP} HP left");

            // เช็คเมื่อพลังชีวิตหมด
            if (currentHP == 0)
            {
                Debug.Log("Player has died!");
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }

        // ตั้งค่าพลังชีวิตเป็น 0
        public void SetZero()
        {
            currentHP = 0;
            Debug.Log("SetZero: Health is now 0");
            var ev = Schedule<HealthIsZero>();
            ev.health = this;
        }

        // ทำให้ผู้เล่นตายโดยลดพลังชีวิตจนหมด
        public void Die()
        {
            // ลดพลังชีวิตจนหมด
            while (currentHP > 0) Decrement();
            // รีเซ็ตพลังชีวิตกลับไปที่ maxHP เมื่อพลังชีวิตหมด
            currentHP = maxHP;
        }

        void Awake()
        {
            currentHP = maxHP; // กำหนดค่าเริ่มต้นให้ HP เริ่มที่ 3
            Debug.Log("Health Initialized: " + currentHP);
        }
    }
}
