using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;
using Roguelike.Module.EnemySpawner;

namespace Roguelike.Module.Enemy {
    public class EnemyController : ObjectController<EnemyController, EnemyModel, IEnemyModel, EnemyView>
    {
        private Animator _anim;

        public void Init(EnemyModel model, EnemyView view, EnemySpawnerController enemySpawner)
        {
            _model = model;
            SetView(view);
            _model.ResetHealth();
            _anim = _view.gameObject.GetComponent<Animator>();
        }

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }

        public override void SetView(EnemyView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnTakeDamage, OnMove, OnDamagingPlayer);
        }

        private void OnMove(Transform playerPosition)
        {
            Vector3 pos = Vector3.MoveTowards(_view.transform.position, playerPosition.position, _model.Speed * Time.deltaTime);
            _view.rbody.MovePosition(pos);
        }

        private void OnTakeDamage(float damage) 
        {
            _model.TakeDamage(damage);
            _anim.SetTrigger("Hit");
            if (_model.Health <= 0)
            {
                OnEnemyDied(_view.gameObject);
                _model.ResetHealth();
            }
        }

        private void OnDamagingPlayer() {
            Publish<PlayerTakeDamageMessage>(new PlayerTakeDamageMessage(_model.Damage));
        }

        private void OnEnemyDied(GameObject enemy) {
            Publish<EnemyDefeatedMessage>(new EnemyDefeatedMessage(enemy, _model.Exp, _model.IsRespawn));
        }
    }
}


