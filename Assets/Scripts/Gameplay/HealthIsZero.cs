using ntdotjsx.Core;
using ntdotjsx.Mechanics;
using static ntdotjsx.Core.Simulation;
using UnityEngine; 

namespace ntdotjsx.Gameplay
{
    public class HealthIsZero : Simulation.Event<HealthIsZero>
    {
        public Health health;

        public override void Execute()
        {
            var ev = Schedule<PlayerDeath>();
            Debug.Log("PlayerDeath event scheduled");

        }
    }

}