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
        public Vector3 SpawnPoint { get; private set; } = new Vector3();
        public float MinYSpawnPoint { get; private set; } = -20f;
        public float MaxYSpawnPoint { get; private set; } = 20f;
        public float MinXSpawnPoint { get; private set; } = -20f;
        public float MaxXSpawnPoint { get; private set; } = 20f;

        private Queue<GameObject> EnemyPool = new Queue<GameObject>();

        public void SetEnemyPrefab(GameObject prefab) {
            EnemyPrefab = prefab;
        }

        public void EnqueueEnemy(GameObject enemy)
        {
            EnemyPool.Enqueue(enemy);
            SetDataAsDirty();
        }
        public GameObject DequeueEnemy()
        {
            return EnemyPool.Dequeue();
        }

        public GameObject GetEnemyInFront()
        {
            return EnemyPool.Peek();
        }

    }

}

