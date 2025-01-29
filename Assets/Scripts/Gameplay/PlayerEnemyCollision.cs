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
            player.Bounce(7);
            if (willHurtEnemy)
            {
                player.Bounce(7);
                var enemyHealth = enemy.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.Decrement();
                    if (!enemyHealth.IsAlive)
                    {
                        Schedule<EnemyDeath>().enemy = enemy;
                        player.Bounce(7);
                    }
                    else
                    {
                        player.Bounce(7);
                    }
                }
                else
                {
                    Schedule<EnemyDeath>().enemy = enemy;
                    player.Bounce(7);
                }
            }
            else
            {
                var playerHealth = player.GetComponent<Health>();
                if (playerHealth != null)
                {
                    if (playerHealth.CurrentHP != 0)
                    {
                        player.Bounce(7);
                        player.animator.SetTrigger("hurt");
                        playerHealth.Decrement();
                        Debug.Log("Player hit! Remaining HP: {playerHealth.CurrentHP}"); // ✅ Debug ตรวจสอบค่า HP
                        if (playerHealth.CurrentHP <= 0)
                        {
                            Schedule<PlayerDeath>();
                        }
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
