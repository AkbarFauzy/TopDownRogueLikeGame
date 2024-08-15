using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Agate.MVC.Base;
using Roguelike.Module.Enemy;

namespace Roguelike.Module.Bullet 
{
    public class BulletController : ObjectController<BulletController, BulletView>
    {
        private BulletPoolController _bulletPool;

        public void Init(BulletView view, BulletPoolController pool) {
            _bulletPool = pool;
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
            _view.GetComponent<Rigidbody2D>().AddForce(direction * 10f, ForceMode2D.Impulse);
        }

        private void OnDespawnBullet() 
        {
            _bulletPool.DespawnBullet(_view.gameObject);
        }

        private void OnEnemyHit(EnemyView enemy)
        {
            enemy.OnTakeDamage?.Invoke(_bulletPool.Model.BulletDamage);
            Debug.Log(_bulletPool.Model.BulletDamage);
            OnDespawnBullet();
        }

    }
}

