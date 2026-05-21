using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Enemy _enemyPrefab;

        public Transform Target => _target;
        public Enemy EnemyPrefab => _enemyPrefab;
    }
}