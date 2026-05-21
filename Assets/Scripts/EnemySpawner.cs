using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private SpawnPoint[] _spawnPoints;
        [SerializeField] private float _spawnDelay = 2f;
        
        private void Start()
        {
            StartCoroutine(SpawnCycle());
        }

        private void Spawn()
        {
            int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Length);
            SpawnPoint spawnPoint = _spawnPoints[randomSpawnPointIndex];
            
            var enemy = Instantiate(spawnPoint.EnemyPrefab);
            enemy.transform.position = spawnPoint.transform.position;

            enemy.Initialize(spawnPoint.Target);
        }

        private IEnumerator SpawnCycle()
        {
            bool shouldSpawn = true;
            var wait = new WaitForSeconds(_spawnDelay);

            while (shouldSpawn)
            {
                yield return wait;
                Spawn();
            }
        }
    }
}