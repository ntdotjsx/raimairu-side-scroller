using ntdotjsx.Core;
using ntdotjsx.Mechanics;
using ntdotjsx.Model;
using UnityEngine;

namespace ntdotjsx.Gameplay
{
    public class PlayerSpawn : Simulation.Event<PlayerSpawn>
    {
        ntdotjsxModel model = Simulation.GetModel<ntdotjsxModel>();

        public override void Execute()
        {
            var player = model.player;

            // ✅ ซ่อน UI "Game Over" ถ้ามี
            if (model.gameOverUI != null)
            {
                model.gameOverUI.SetActive(false);
            }

            player.collider2d.enabled = true;
            player.controlEnabled = false;

            if (player.audioSource && player.respawnAudio)
                player.audioSource.PlayOneShot(player.respawnAudio);

            player.health.Increment();
            player.Teleport(model.spawnPoint.transform.position);
            player.jumpState = PlayerController.JumpState.Grounded;
            player.animator.SetBool("dead", false);

            model.virtualCamera.m_Follow = player.transform;
            model.virtualCamera.m_LookAt = player.transform;

            Simulation.Schedule<EnablePlayerInput>(2f);
        }
    }
}
