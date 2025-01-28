using ntdotjsx.Core;
using ntdotjsx.Mechanics;
using ntdotjsx.Model;
using UnityEngine;
using static ntdotjsx.Core.Simulation;

namespace ntdotjsx.Gameplay
{
    public class PlayerEnemyCollision : Simulation.Event<PlayerEnemyCollision>
    {
        public EnemyController enemy;
        public PlayerController player;

        ntdotjsxModel model = Simulation.GetModel<ntdotjsxModel>();

        public override void Execute()
        {
            var willHurtEnemy = player.Bounds.center.y >= enemy.Bounds.max.y;

            if (willHurtEnemy)
            {
                var enemyHealth = enemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.Decrement();
                    if (!enemyHealth.IsAlive)
                    {
                        Schedule<EnemyDeath>().enemy = enemy;
                        player.Bounce(2);
                    }
                    else
                    {
                        player.Bounce(7);
                    }
                }
                else
                {
                    Schedule<EnemyDeath>().enemy = enemy;
                    player.Bounce(2);
                }
            }
            else
            {
                var playerHealth = player.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.Decrement();
                    Debug.Log($"Player hit! Remaining HP: {playerHealth.CurrentHP}"); // ✅ Debug ตรวจสอบค่า HP

                    if (playerHealth.CurrentHP <= 0) // ✅ แก้เงื่อนไขให้ชัดเจน
                    {
                        Debug.Log("Player has died!"); // ✅ Debug เช็คว่าผู้เล่นตายจริงหรือไม่
                        Schedule<PlayerDeath>();
                    }
                    else
                    {
                        player.Bounce(3); // เด้งเล็กน้อยเมื่อโดนโจมตี
                    }
                }
                else
                {
                    Schedule<PlayerDeath>();
                }
            }
        }
    }
}
