using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;
using Roguelike.Module.EnemySpawner;

namespace Roguelike.Module.Enemy {
    public class EnemyController : ObjectController<EnemyController, EnemyModel, IEnemyModel, EnemyView>
    {
        private EnemySpawnerController _enemySpawner;
        public void Init(EnemyModel model, EnemyView view)
        {
            _model = model;
            SetView(view);
            _model.ResetHealth();
        }

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }

        public override void SetView(EnemyView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnCollideWithBullet, OnMoveEnemy);
        }

        private void OnMoveEnemy(Transform playerPosition)
        {
            Vector3 pos = Vector3.MoveTowards(_view.transform.position, playerPosition.position, _model.Speed * Time.deltaTime);
            _view.rbody.MovePosition(pos);
        }

        private void OnCollideWithBullet(int bulletDamage) 
        {
            _model.TakeDamage(bulletDamage);
            if (_model.Health <= 0)
            {
                OnEnemyDied(_view.gameObject);
                _model.ResetHealth();
            }
        }

        private void OnEnemyDied(GameObject enemy) {
            Publish<EnemyDefeatedMessage>(new EnemyDefeatedMessage(enemy));
        }


        public void OnGameOver(GameOverMessage message)
        {

        }
    }
}


