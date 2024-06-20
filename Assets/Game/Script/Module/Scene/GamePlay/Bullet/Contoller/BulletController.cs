using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Agate.MVC.Base;
using Roguelike.Module.Enemy;

namespace Roguelike.Module.Bullet 
{
    public class BulletController : ObjectController<BulletController, BulletModel, IBulletModel, BulletView>
    {

        private BulletPoolController _bulletPool;

        public void Init(BulletModel model, BulletView view) {
            _model = model;
            SetView(view);
        }

        public override void SetView(BulletView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnMoveBullet, OnDespawnBullet, OnEnemyHit);
        }

        private void OnMoveBullet() 
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector2 firePointPosition = _bulletPool.Model.SpawnPoint.position;
            Vector2 direction = (mousePosition - firePointPosition).normalized;
            _view.GetComponent<Rigidbody2D>().AddForce(direction * _model.Force, ForceMode2D.Impulse);
        }

        private void OnDespawnBullet() 
        {
            float bulletXPosition = _view.transform.position.x;
            float bulletYPosition = _view.transform.position.y;

            bool isDespawn = Mathf.Abs(bulletXPosition) >= _bulletPool.Model.DespawnPosition.x || Mathf.Abs(bulletYPosition) >= _bulletPool.Model.DespawnPosition.y;
            if (isDespawn)
            {
                /*GameObject bullet = _model.DequeueObstacle();*/
                _view.gameObject.SetActive(false);
                _bulletPool.SpawnBullet(_view.gameObject);
            }
        }

        private void OnEnemyHit(EnemyView enemy)
        {
            enemy.OnTakeDamage?.Invoke(_model.Damage);
            GameObject bullet = _view.gameObject;
            bullet.SetActive(false);
            _bulletPool.SpawnBullet(_view.gameObject);
        }

    }
}

