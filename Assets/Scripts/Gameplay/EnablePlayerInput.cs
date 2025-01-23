using ntdotjsx.Core;
using ntdotjsx.Model;

namespace ntdotjsx.Gameplay
{
    public class EnablePlayerInput : Simulation.Event<EnablePlayerInput>
    {
        ntdotjsxModel model = Simulation.GetModel<ntdotjsxModel>();

        public override void Execute()
        {
            var player = model.player;
            player.controlEnabled = true;
        }
    }
}