using System.Collections; // เพิ่มบรรทัดนี้
using UnityEngine;

namespace ntdotjsx.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;
        public string nextSceneName = "NextSceneName";

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        // ฟังก์ชันที่จะใช้ในการเปลี่ยน Scene
        public void TriggerSceneChange(string sceneName)
        {
            StartCoroutine(WaitAndChangeScene(sceneName));
        }

        private IEnumerator WaitAndChangeScene(string sceneName)
        {
            yield return new WaitForSeconds(3f);
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
