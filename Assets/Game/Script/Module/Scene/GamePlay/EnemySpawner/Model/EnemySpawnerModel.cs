using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.EnemySpawner
{
    public class EnemySpawnerModel : BaseModel, IEnemySpawnerModel
    {
        public Transform Player { get; private set; }
        public int PoolSize { get; private set; } = 30;
        public Vector2 SpawnPoint { get; private set; } = new Vector2();
        public float MinYSpawnPoint { get; private set; } = 20f;
        public float MaxYSpawnPoint { get; private set; } = 30f;
        public float MinXSpawnPoint { get; private set; } = 20f;
        public float MaxXSpawnPoint { get; private set; } = 30f;

        public float Timer;

        private List<GameObject> EnemyPool = new List<GameObject>();

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

        public void AddTime()
        {
            Timer += Time.deltaTime;
            SetDataAsDirty();
        }

        public GameObject GetEnemyInFront()
        {
            return EnemyPool[0];
        }

    }

}

