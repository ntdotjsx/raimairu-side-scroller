using ntdotjsx.Core;
using ntdotjsx.Mechanics;
using ntdotjsx.Model;
using UnityEngine;
using static ntdotjsx.Core.Simulation;

namespace ntdotjsx.Gameplay
{
    public class PlayerItemCollision : Simulation.Event<PlayerItemCollision>
    {
        public ItemPickup item;
        public PlayerController player;
        ntdotjsxModel model = Simulation.GetModel<ntdotjsxModel>();
        public override void Execute()
        {

        }
    }
}