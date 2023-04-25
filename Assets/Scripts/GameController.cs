using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
// Author: Feifei
public class GameController : MonoBehaviour
    {
        private bool isWin;
        public GameManagerScript gameManager;
        public GameObject EnemyPrefab;
        public int NumberOfEnemy = 5; // numebr of enemy generated per section
        public int killCount = 0;
        public int HurtCount = 0;
        public Text killCountText; 


    void Start()
        {
         killCountText = GameObject.Find("KillCount").GetComponent<Text>();
            // Respawn enemies in main sections
            for (int i = 0; i < NumberOfEnemy; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-48, 27), 0.5f, Random.Range(-13, 17));
                Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            }
            // Respawn enemies in righ side sections
            for (int i = 0; i < NumberOfEnemy; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(31, 46), 0.5f, Random.Range(-8, 48));
                Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            }
            // Respawn enemies in top side sections

            for (int i = 0; i < NumberOfEnemy; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-46,-9), 0.5f, Random.Range(22, 46));
                Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            }
            // Respawn enemies in main sections
            for (int i = 0; i < NumberOfEnemy; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-48, 27), 0.5f, Random.Range(-47, -17));
                Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            }
    }

    // Check if player wins when an enemy is killed
    public void CheckWinCondition()
    {
        killCount++;
        Debug.Log("Killcount +1");
        killCountText.text = "Kill Count: " + killCount.ToString();
        if (killCount >= 5)
        {
            gameManager.gameOver();
            // Player wins
            Debug.Log("You Win!" + killCount);
        }
    }

    public void hurtPlayer()
    {
        Debug.Log("Check player hurt");

        HurtCount++;
        if (HurtCount >= 5)
        {
            // Player loss
            gameManager.gameOver();
            Debug.Log("You Loss!");
        }
    }
}
