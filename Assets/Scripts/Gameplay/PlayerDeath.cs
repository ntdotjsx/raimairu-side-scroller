using System.Collections;
using System.Collections.Generic;
using ntdotjsx.Core;
using ntdotjsx.Model;
using UnityEngine;

namespace ntdotjsx.Gameplay
{
    public class PlayerDeath : Simulation.Event<PlayerDeath>
    {
        ntdotjsxModel model = Simulation.GetModel<ntdotjsxModel>();

        public override void Execute()
        {
            var player = model.player;

            if (player.health.IsAlive)
            {
                // ✅ Player ยังไม่ตาย
            }
            else
            {
                player.health.Die();
                model.virtualCamera.m_Follow = null;
                model.virtualCamera.m_LookAt = null;
                player.controlEnabled = false;

                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);

                // 📄 เล่น Animation ตาย
                player.animator.SetTrigger("hurt");
                player.animator.SetBool("dead", true);

                // ✅ แสดง UI Game Over ถ้ามี
                if (model.gameOverUI != null)
                {
                    model.gameOverUI.SetActive(true);
                }

                Debug.Log("Game Over UI: " + model.gameOverUI);

                // 😁 Schedule การเกิดใหม่
                Simulation.Schedule<PlayerSpawn>(2);
            }
        }
    }
}