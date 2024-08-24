using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;
using Roguelike.Module.Enemy;

namespace Roguelike.Module.Weapon {
    public class LandmineView : BaseView
    {
        private UnityAction _onDespawnLandmine;
        private UnityAction<EnemyView> _onEnemyHit;

        private float timeSinceLastSpawn;

        public void SetCallbacks(UnityAction onDespawnLandmine, UnityAction<EnemyView> onEnemyHit)
        {
            _onDespawnLandmine = onDespawnLandmine;
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            bool isCollideWithEnemy = collision.gameObject.CompareTag("Enemy");
            if (isCollideWithEnemy)
            {
                _onEnemyHit?.Invoke(collision.gameObject.GetComponent<EnemyView>());
            }
        }

        private void Update()
        {
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn > 10f)
            {
                timeSinceLastSpawn = 0f;
                _onDespawnLandmine?.Invoke();
            }
        }
        private void OnEnable()
        {
            timeSinceLastSpawn = 0f;
        }

        private void OnDisable()
        {
            _onDespawnLandmine?.Invoke();
        }

    }

}

