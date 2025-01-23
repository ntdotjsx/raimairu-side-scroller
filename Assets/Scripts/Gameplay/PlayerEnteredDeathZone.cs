using ntdotjsx.Core;
using ntdotjsx.Mechanics;
using ntdotjsx.Model;

namespace ntdotjsx.Gameplay
{
    public class PlayerEnteredDeathZone : Simulation.Event<PlayerEnteredDeathZone>
    {
        public DeathZone deathzone;

        ntdotjsxModel model = Simulation.GetModel<ntdotjsxModel>();

        public override void Execute()
        {
            Simulation.Schedule<PlayerDeath>(0);
        }
    }
}