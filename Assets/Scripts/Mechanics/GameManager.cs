using System.Collections; // เพิ่มบรรทัดนี้
using UnityEngine;

namespace ntdotjsx.Gameplay
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

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

        // ฟังก์ชันที่จะใช้ในการเปลี่ยน Scene ถัดไป
        public void TriggerSceneChange()
        {
            StartCoroutine(WaitAndChangeScene());
        }

        private IEnumerator WaitAndChangeScene()
        {
            yield return new WaitForSeconds(3f); // รอ 3 วินาที
            int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1; // ไปยัง Scene ถัดไปใน Build Settings

            // ตรวจสอบว่า Scene ถัดไปมีอยู่หรือไม่
            if (nextSceneIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
            }
            else
            {
                Debug.LogWarning("No next scene found in the Build Settings.");
            }
        }
    }
}
