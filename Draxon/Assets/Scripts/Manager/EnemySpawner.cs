using System.Collections;
using System.Collections.Generic;
using Entities;
using UnityEngine;

namespace Manager
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemySpawnConfig _spawnConfig;

        
        private Coroutine _spawnRoutine;

        private Dictionary<Transform, EntityBase> _activeEnemyToSpawnPointMapping = new();
        
        private void Start()
        {
            StartSpawning();
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
        
        public void StartSpawning()
        {
            if (_spawnRoutine != null) StopSpawning();
            StartCoroutine(SpawnCoroutine());
        }

        public void StopSpawning()
        {
            if (_spawnRoutine != null)
                StopCoroutine(_spawnRoutine);
        }

        
        private IEnumerator SpawnCoroutine()
        {
            while (isActiveAndEnabled)
            {
                yield return new WaitForSeconds(_spawnConfig.SpawnDelay);
                Spawn();
            }
        }

        private void Spawn()
        {
            var spawnPoint = GetSpawnPoint();
            if (!spawnPoint) return;
                
            var enemyToSpawn = _spawnConfig.GetNextEnemy();
                
            var enemy = Instantiate(enemyToSpawn);
            enemy.transform.position = spawnPoint.position;
            enemy.transform.rotation = spawnPoint.rotation;
                
            enemy.Health.Die += EnemyDied;
                
            _activeEnemyToSpawnPointMapping.Add(spawnPoint, enemy);
            
            return;
            void EnemyDied()
            {
                enemy.Health.Die -= EnemyDied;
                _activeEnemyToSpawnPointMapping.Remove(spawnPoint);
            }
        }

        private Transform GetSpawnPoint()
        {
            foreach (var point in _spawnPoints)
            {
                if (_activeEnemyToSpawnPointMapping.ContainsKey(point))
                    continue;
                return point;
            }
            
            return null;
        }
    }
}