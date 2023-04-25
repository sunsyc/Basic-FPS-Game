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
        public int HurtCount = 0;

    public GameObject speedPickupPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;
    private float timeSinceLastSpawn;


    void Start()
        {

            // Respawn enemies
            for (int i = 0; i < NumberOfEnemy; i++)
            {
                Vector3 spawnPosition = new Vector3(i + Random.Range(-1, 3), 0.5f, i + Random.Range(0, 3));
                Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            }

        SpawnSpeedPickup();
    }

    // Check if player wins when an enemy is killed
    public void CheckWinCondition()
    {
        killCount++;
        Debug.Log("Killcount +1");
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

    void SpawnSpeedPickup()
    {
        //int spawnIndex = Random.Range(0, spawnPoints.Length);
        //Instantiate(speedPickupPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        Vector3 spawnPosition = new Vector3(Random.Range(-1, 3), 0.5f,Random.Range(0, 3));
        Instantiate(speedPickupPrefab, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnSpeedPickup();
            timeSinceLastSpawn = 0f;
        }
    }

}
