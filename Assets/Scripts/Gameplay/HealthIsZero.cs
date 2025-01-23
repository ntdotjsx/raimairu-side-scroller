using ntdotjsx.Core;
using ntdotjsx.Mechanics;
using static ntdotjsx.Core.Simulation;

namespace ntdotjsx.Gameplay
{
    public class HealthIsZero : Simulation.Event<HealthIsZero>
    {
        public Health health;

        public override void Execute()
        {
            Schedule<PlayerDeath>();
        }
    }
}