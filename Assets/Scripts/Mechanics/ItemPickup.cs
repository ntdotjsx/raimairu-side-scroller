using UnityEngine;
using ntdotjsx.Mechanics;  // นำเข้า Health ของผู้เล่น

public class ItemPickup : MonoBehaviour
{
    public int healAmount = 1; // จำนวนเลือดที่จะเพิ่มเมื่อเก็บไอเทม

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ตรวจสอบว่าเป็นผู้เล่นหรือไม่
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            Debug.Log("Player collided with health item!");
            Health playerHealth = player.health;

            // เพิ่มเลือดให้ผู้เล่น ถ้ายังไม่เต็มเลือด
            if (playerHealth.CurrentHP < playerHealth.maxHP)
            {
                Debug.Log($"Increasing health by {healAmount} HP");
                playerHealth.Increment(healAmount); // เพิ่มเลือด
                Debug.Log("Item destroyed!");  // ดูว่าไอเทมถูกทำลายหรือไม่
                Destroy(gameObject); // ลบไอเทมออกจากฉาก
            }
        }
    }


}
