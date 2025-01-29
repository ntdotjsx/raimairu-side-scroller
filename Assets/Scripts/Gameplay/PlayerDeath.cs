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
                // ✅ Player ยังไม่ตายให้มันทำเหี้ยไรดี
            }
            else
            {
                player.health.Die();
                model.virtualCamera.m_Follow = null;
                model.virtualCamera.m_LookAt = null;
                player.controlEnabled = false;

                if (player.audioSource && player.ouchAudio)
                    player.audioSource.PlayOneShot(player.ouchAudio);

                // 📄 ให้เล่น Animotion ก่อนส่งแม่งไปเกิด
                player.animator.SetTrigger("hurt");
                player.animator.SetBool("dead", true);

                Simulation.Schedule<PlayerSpawn>(2);
                // 😁 ตายห่าและส่งไปเกิดใหม่
            }
        }

    }
}