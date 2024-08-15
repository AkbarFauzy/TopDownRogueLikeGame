using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;



namespace Roguelike.Module.Bullet
{
    public class BulletPoolView : ObjectView<IBulletPoolModel>
    {
        public GameObject BulletPrefab;

        private UnityAction _onSpawnBullet;
        private float timeSinceLastBullet = 0f;

        public void SetCallbacks(UnityAction onSpawnBullet)
        {
            _onSpawnBullet = onSpawnBullet;
        }

        protected override void InitRenderModel(IBulletPoolModel model)
        {
            /*transform.position = _model.Position;*/
        }

        protected override void UpdateRenderModel(IBulletPoolModel model)
        {
           /* transform.position = _model.Position;*/
        }

        private void Update()
        {
            timeSinceLastBullet += Time.deltaTime;
            if (timeSinceLastBullet > 1f) {
                timeSinceLastBullet = 0;
                _onSpawnBullet?.Invoke();
            }
        }
    }
}

