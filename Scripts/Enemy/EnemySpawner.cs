using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JG
{
    public class EnemySpawner : MonoBehaviour
    {
        PlayerStats PlayerStats;
        EnemyStats enemyStats;
        public GameObject _enemySpawnReady;
        public float spawnInterval;


        private void Awake()
        {
            PlayerStats = FindObjectOfType<PlayerStats>();
            enemyStats = FindObjectOfType<EnemyStats>();
        }

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
            Instantiate(_enemySpawnReady);
        }

        IEnumerator SpawnRoutine()
        {
            Vector3 spawnPos = Vector3.zero;

            while(PlayerStats.isAlive == false)
            {
                yield return new WaitForSeconds(15f);
                
                spawnPos.x = 0;
                spawnPos.y = 0;
                spawnPos.z = -30;
                
                Instantiate(_enemySpawnReady, spawnPos, Quaternion.identity);

               
            }
        }
    }
}
