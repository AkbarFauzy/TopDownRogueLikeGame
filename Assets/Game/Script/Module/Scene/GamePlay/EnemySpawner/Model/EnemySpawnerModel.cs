using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.EnemySpawner
{
    public class EnemySpawnerModel : BaseModel, IEnemySpawnerModel
    {
        public GameObject EnemyPrefab { get; private set; }
        public Transform Player { get; private set; }
        public int PoolSize { get; private set; } = 20;
        public Vector2 SpawnPoint { get; private set; } = new Vector2();
        public float MinYSpawnPoint { get; private set; } = 10f;
        public float MaxYSpawnPoint { get; private set; } = 20f;
        public float MinXSpawnPoint { get; private set; } = 10f;
        public float MaxXSpawnPoint { get; private set; } = 20f;

        private List<GameObject> EnemyPool = new List<GameObject>();

        public void SetEnemyPrefab(GameObject prefab) {
            EnemyPrefab = prefab;
        }

        public void AddEnemy(GameObject enemy)
        {
            EnemyPool.Add(enemy);
            SetDataAsDirty();
        }

        public void RemoveEnemy(GameObject enemy)
        {
           EnemyPool.Remove(enemy);
           SetDataAsDirty();
        }

        public GameObject GetEnemyInFront()
        {
            return EnemyPool[0];
        }

    }

}

