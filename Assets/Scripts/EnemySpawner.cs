using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private float _spawnDelay = 2f;
        
        private void Start()
        {
            StartCoroutine(SpawnCycle());
        }

        private void Spawn()
        {
            int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Length);
            Transform spawnPoint = _spawnPoints[randomSpawnPointIndex];
            
            var enemy = Instantiate(_prefab);
            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = spawnPoint.rotation;
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