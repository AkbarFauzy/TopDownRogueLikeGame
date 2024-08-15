using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;
using Roguelike.Module.Enemy;

namespace Roguelike.Module.Bullet 
{
    public class BulletView : BaseView
    {
        private UnityAction _onMoveBullet;
        private UnityAction _onDespawnBullet;
        private UnityAction<EnemyView> _onEnemyHit;

        private float timeSinceLastSpawn;

        public void SetCallbacks(UnityAction onMoveBullet , UnityAction onDespawnBullet, UnityAction<EnemyView> onEnemyHit)
        {
            _onMoveBullet = onMoveBullet;
            _onDespawnBullet = onDespawnBullet;
            _onEnemyHit = onEnemyHit;
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
            timeSinceLastSpawn = 0f;
            _onMoveBullet?.Invoke();
        }

        private void Update()
        {
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn > 2f)
            {
                _onDespawnBullet?.Invoke();
            }
        }
        private void OnEnable()
        {
            timeSinceLastSpawn = 0f;
            _onMoveBullet?.Invoke();
        }
    }
}

