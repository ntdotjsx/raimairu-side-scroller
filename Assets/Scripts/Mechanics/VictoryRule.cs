using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryRule : MonoBehaviour
{
    public int enemyCount = 1; // จำนวนศัตรูที่ต้องกำจัดเพื่อชนะ
    public string victoryMessage = "Victory!"; // ข้อความแจ้งเตือนเมื่อชนะ

    void Update()
    {
        CheckVictory();
    }

    void CheckVictory()
    {
        if (enemyCount <= 0)
        {
            Debug.Log(victoryMessage);
            OnVictory();
        }
    }

    void OnVictory()
    {
        // สามารถเพิ่มโค้ดเพื่อเปลี่ยน Scene หรือแสดง UI แจ้งเตือน
        Debug.Log("You have won the game!");
    }

    public void EnemyDefeated()
    {
        enemyCount--;
        CheckVictory();
    }
}
