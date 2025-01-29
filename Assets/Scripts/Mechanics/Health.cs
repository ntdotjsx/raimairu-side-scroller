using System;
using ntdotjsx.Gameplay;
using UnityEngine;
using static ntdotjsx.Core.Simulation;

namespace ntdotjsx.Mechanics
{
    public class Health : MonoBehaviour
    {
        public int maxHP = 3;  // ✅ ให้ผู้เล่นมี 3 ชีวิต
        public bool IsAlive => currentHP > 0;

        private int currentHP;
        public int CurrentHP => currentHP;

        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 3, 0, maxHP);
        }

        public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            // Debug.Log($"Health Decremented: {currentHP} HP left"); // ✅ Debug ตรวจสอบค่า HP
            if (currentHP == 0)
            {
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }

        public void SetZero()
        {
            currentHP = 0;
            Debug.Log("SetZero");
            if (currentHP == 0)
            {
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }

        public void Die()
        {
            while (currentHP > 0) Decrement();
        }

        void Awake()
        {
            currentHP = maxHP; // ✅ กำหนดให้ HP เริ่มที่ 3
        }
    }
}
