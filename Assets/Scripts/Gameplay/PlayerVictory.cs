using ntdotjsx.Gameplay;
using ntdotjsx.Core;
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

            if (model.gameVicUI != null)
            {
                model.gameVicUI.SetActive(true);
            }

            GameManager.Instance.TriggerSceneChange();
        }
    }
}
