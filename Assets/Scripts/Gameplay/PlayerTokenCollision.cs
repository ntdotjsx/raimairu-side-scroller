using ntdotjsx.Core;
using ntdotjsx.Mechanics;
using ntdotjsx.Model;
using UnityEngine;

namespace ntdotjsx.Gameplay
{
    public class PlayerTokenCollision : Simulation.Event<PlayerTokenCollision>
    {
        public PlayerController player;
        public TokenInstance token;

        ntdotjsxModel model = Simulation.GetModel<ntdotjsxModel>();

        public override void Execute()
        {
            AudioSource.PlayClipAtPoint(token.tokenCollectAudio, token.transform.position);
        }
    }
}