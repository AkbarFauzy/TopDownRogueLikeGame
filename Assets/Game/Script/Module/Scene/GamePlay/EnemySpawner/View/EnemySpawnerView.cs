using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;

namespace Roguelike.Module.EnemySpawner 
{
    public class EnemySpawnerView : ObjectView<IEnemySpawnerModel>
    {
        [SerializeField]
        public List<EnemySpawnerScriptableObject> Enemy;

        private UnityAction _onTimer;

        public void SetCallbacks(UnityAction onTimer)
        {
            _onTimer = onTimer;
        }

        private void Update()
        {
            _onTimer?.Invoke();
        }


        protected override void InitRenderModel(IEnemySpawnerModel model)
        {
        
        }

        protected override void UpdateRenderModel(IEnemySpawnerModel model)
        {
            
        }

    }
}


