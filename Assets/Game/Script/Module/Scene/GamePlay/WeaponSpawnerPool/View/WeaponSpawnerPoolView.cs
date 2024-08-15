using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;


namespace Roguelike.Module.Weapon {
    public class WeaponSpawnerPoolView : ObjectView<IWeaponSpawnerPoolModel>
    {
        public GameObject ObjectPrefab;

        private UnityAction _onSpawnObject;
        [SerializeField] private float spawnInterval;
        [SerializeField] private int numberOfObjectOnField;
        private float timeSinceLastObject = 0f;

        public void SetCallbacks(UnityAction onSpawnBullet)
        {
            _onSpawnObject = onSpawnBullet;
        }

        private void Update()
        {
            if (_model.ObjectOnFieldCount >= numberOfObjectOnField)
                return;

            timeSinceLastObject += Time.deltaTime;
            if (timeSinceLastObject > spawnInterval)
            {
                timeSinceLastObject = 0;
                _onSpawnObject?.Invoke();
            }
        }

        protected override void InitRenderModel(IWeaponSpawnerPoolModel model)
        {
          
        }

        protected override void UpdateRenderModel(IWeaponSpawnerPoolModel model)
        {

        }
    }
}

