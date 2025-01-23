using ntdotjsx.Mechanics;
using UnityEngine;

namespace ntdotjsx.Model
{
    [System.Serializable]
    public class ntdotjsxModel
    {
        public Cinemachine.CinemachineVirtualCamera virtualCamera;
        public PlayerController player;
        public Transform spawnPoint;
        public float jumpModifier = 1.5f;
        public float jumpDeceleration = 0.5f;
    }
}