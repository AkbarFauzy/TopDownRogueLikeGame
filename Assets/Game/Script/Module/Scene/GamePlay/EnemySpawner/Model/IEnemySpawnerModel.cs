using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.EnemySpawner {
    public interface IEnemySpawnerModel : IBaseModel
    {
        public GameObject EnemyPrefab { get; }
        public Transform Player { get; }
        public int PoolSize { get; }

    }

}
