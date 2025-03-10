using ntdotjsx.Mechanics;
using ntdotjsx.UI;
using UnityEngine;

namespace ntdotjsx.UI
{
    public class MetaGameController : MonoBehaviour
    {
        public MainUIController mainMenu;
        public Canvas[] gamePlayCanvasii;
        public GameController gameController;
        bool showMainCanvas = false;

        void OnEnable()
        {
            _ToggleMainMenu(showMainCanvas);
        }
        public void ToggleMainMenu(bool show)
        {
            if (this.showMainCanvas != show)
            {
                _ToggleMainMenu(show);
            }
        }

        void _ToggleMainMenu(bool show)
        {
            if (show)
            {
                Time.timeScale = 0;
                mainMenu.gameObject.SetActive(true);
                foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(false);
            }
            else
            {
                Time.timeScale = 1;
                mainMenu.gameObject.SetActive(false);
                foreach (var i in gamePlayCanvasii) i.gameObject.SetActive(true);
            }
            this.showMainCanvas = show;
        }

        void Update()
        {
            if (Input.GetButtonDown("Menu"))
            {
                ToggleMainMenu(show: !showMainCanvas);
            }
        }

    }
}
