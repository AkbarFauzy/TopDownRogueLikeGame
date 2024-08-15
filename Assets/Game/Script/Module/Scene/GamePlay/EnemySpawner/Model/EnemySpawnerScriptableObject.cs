using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Roguelike.Module.EnemySpawner {
    [CreateAssetMenu(fileName = "Enemy", menuName = "ScriptableObjects/Enemy")]
    public class EnemySpawnerScriptableObject : ScriptableObject
    {
        public GameObject EnemyPrefab;
        public float Damage;
        public int Exp;
        public float Health;
        public int PoolSize;
        public float SpawnAt;
        public bool IsRespawn;
    }
}

