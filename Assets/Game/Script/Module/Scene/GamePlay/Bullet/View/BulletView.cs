using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Agate.MVC.Base;
using Roguelike.Module.Enemy;

namespace Roguelike.Module.Bullet 
{
    public class BulletView : ObjectView<IBulletModel>
    {
        private UnityAction _onMoveBullet;
        private UnityAction _onDespawnBullet;
        private UnityAction<EnemyView> _onEnemyHit;

        public void SetCallbacks(UnityAction onMoveBullet , UnityAction onDespawnBullet, UnityAction<EnemyView> onEnemyHit)
        {
            _onMoveBullet = onMoveBullet;
            _onDespawnBullet = onDespawnBullet;
            _onEnemyHit = onEnemyHit;
        }

        protected override void InitRenderModel(IBulletModel model)
        {
          
        }

        protected override void UpdateRenderModel(IBulletModel model)
        {
   
        }

        private void OnCollisionEnter2D(Collision2D collisionInfo)
        {
            bool isCollideWithEnemy = collisionInfo.gameObject.CompareTag("Enemy");
            if (isCollideWithEnemy)
            {
                _onEnemyHit?.Invoke(collisionInfo.gameObject.GetComponent<EnemyView>());
            }
        }

        private void Start()
        {
            _onMoveBullet?.Invoke();
        }

        private void Update()
        {
            _onDespawnBullet?.Invoke();
        }

        private void OnEnable()
        {
            _onMoveBullet?.Invoke();
        }

    }
}

