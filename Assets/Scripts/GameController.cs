using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

    public class GameController : MonoBehaviour
    {
        public GameObject EnemyPrefab;
        public int NumberOfEnemy = 8;
        public int killCount = 0;
        public int HurtCount = 0;

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
        killCount++;
        Debug.Log("Killcount +1");
        if (killCount >= 5)
        {
            // Player wins
            Debug.Log("You Win!" + killCount);
        }
    }

    public void hurtPlayer()
    {
        //Debug.Log("CheckLossing running");

        HurtCount++;
        if (HurtCount >= 10)
        {
            // Player loss
            Debug.Log("You Loss!");
        }
    }
}
