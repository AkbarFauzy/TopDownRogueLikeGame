using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.EnemySpawner 
{
    public class EnemySpawnerView : ObjectView<IEnemySpawnerModel>
    {
        [SerializeField]
        public Transform PlayerPosition;
        [SerializeField]
        public GameObject EnemyPrefab;

        protected override void InitRenderModel(IEnemySpawnerModel model)
        {
        
        }

        protected override void UpdateRenderModel(IEnemySpawnerModel model)
        {
            
        }

    }
}

