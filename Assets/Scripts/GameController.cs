using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

    public class GameController : MonoBehaviour
    {
        private bool isWin;
        public GameManagerScript gameManager;
        public GameObject EnemyPrefab;
        public int NumberOfEnemy = 8;
        public int killCount = 0;
        void Start()
        {

            // Respawn enemies
            for (int i = 0; i < NumberOfEnemy; i++)
            {
                Vector3 spawnPosition = new Vector3(i + Random.Range(-1, 3), 0.5f, i + Random.Range(0, 3));
                Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            }

        }

    // Check if player wins when an enemy is killed
    public void CheckWinCondition()
    {
        Debug.Log("CheckWinCondition running");

        killCount++;
        if (killCount >= 5)
        {
            gameManager.gameOver();
            // Player wins
            Debug.Log("You Win!");
        }
    }
}
