using ntdotjsx.Core;
using ntdotjsx.Model;
using UnityEngine.UI;
using UnityEngine;

namespace ntdotjsx.Mechanics
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; }
        public ntdotjsxModel model = Simulation.GetModel<ntdotjsxModel>();

        void OnEnable()
        {
            Instance = this;
        }

        void OnDisable()
        {
            if (Instance == this) Instance = null;
        }

        void Update()
        {
            if (Instance == this) Simulation.Tick();
        }
    }
}