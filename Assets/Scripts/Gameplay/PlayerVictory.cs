using ntdotjsx.Core;
using ntdotjsx.Mechanics;
using ntdotjsx.Model;

namespace ntdotjsx.Gameplay
{
    public class PlayerVictory : Simulation.Event<PlayerVictory>
    {

        ntdotjsxModel model = Simulation.GetModel<ntdotjsxModel>();

        public override void Execute()
        {
            model.player.animator.SetTrigger("victory");
            model.player.controlEnabled = false;
        }
    }
}