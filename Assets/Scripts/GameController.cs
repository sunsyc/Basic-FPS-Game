using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

    public class GameController : MonoBehaviour
    {
        public GameObject EnemyPrefab;
        public int NumberOfEnemy = 8;

        void Start()
        {

            // Respawn enemies
            for (int i = 0; i < NumberOfEnemy; i++)
            {
                Vector3 spawnPosition = new Vector3(i + Random.Range(-1, 3), 0.5f, i + Random.Range(0, 3));
                Instantiate(EnemyPrefab, spawnPosition, Quaternion.identity);
            }

        }
    }
