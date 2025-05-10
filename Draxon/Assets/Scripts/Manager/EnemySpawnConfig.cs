using System.Collections.Generic;
using Entities;
using UnityEngine;
using Utils;

namespace Manager
{
    [CreateAssetMenu(menuName = "Configs/EnemySpawnConfig")]
    public class EnemySpawnConfig : ScriptableObject
    {
        [SerializeField] private List<EntityBase> enemiesToSpawn;

        [SerializeField] private float spawnDelay;
        public float SpawnDelay => spawnDelay;

        public EntityBase GetNextEnemy() => enemiesToSpawn.GetRandom();
    }
}