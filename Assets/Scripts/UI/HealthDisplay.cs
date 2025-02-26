using UnityEngine;
using TMPro;
using ntdotjsx.Mechanics;  // เพิ่ม namespace นี้

public class HealthDisplay : MonoBehaviour
{
    public TextMeshProUGUI healthText;  // UI Text ที่แสดงพลังชีวิต
    private PlayerController playerController;  // ตัวแปรเก็บอ้างอิงไปที่ PlayerController

    void Start()
    {
        // ค้นหา PlayerController ใน Scene
        playerController = FindObjectOfType<PlayerController>();  
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found!");
        }
    }

    void Update()
    {
        // ตรวจสอบว่า healthText และ playerController ไม่เป็น null
        if (healthText != null && playerController != null && playerController.health != null)
        {
            // แสดงพลังชีวิต (เช็คค่า CurrentHP)
            healthText.text = "Health: " + playerController.health.CurrentHP.ToString();
        }
        else
        {
            Debug.LogWarning("healthText or playerController or playerController.health is null");
        }
    }
}
