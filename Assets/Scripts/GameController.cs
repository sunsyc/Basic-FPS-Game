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
        public int NumberOfEnemy = 8; // numebr of enemy generated per section
        public int killCount = 0;
        public int HurtCount = 0;
        public Text killCountText;
        public Text HealthCountText;

    public GameObject speedPickupPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 5f;
    private float timeSinceLastSpawn;


    void Start()
        {
        SpawnSpeedPickup();

        killCountText = GameObject.Find("KillCount").GetComponent<Text>();
        HealthCountText = GameObject.Find("healthCount").GetComponent<Text>();

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
        if (killCount >= 15)
        {
            gameManager.gameOver();
            // Player wins
            Debug.Log("You Win!" + killCount);
        }
    }

    public void hurtPlayer()
    {
        HurtCount++;
        Debug.Log("Check player hurt");
        int healthDisplay = 100 - 10 * HurtCount;
        HealthCountText.text = " Health Count:  " + healthDisplay.ToString();
        if (HurtCount >= 10)
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
        Vector3 spawnPosition = new Vector3(Random.Range(-1, 3), 0.5f, Random.Range(0, 3));
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
