using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Module.Enemy;

namespace Roguelike.Module.Weapon {
    public class LandmineController : ObjectController<LandmineController, LandmineView>
    {
        WeaponSpawnerPoolController _objectPool;
        Animator _anim;

        public void Init(LandmineView view, WeaponSpawnerPoolController pool)
        {
            _objectPool = pool;
            SetView(view);
            _anim = _view.GetComponent<Animator>();
        }

        public override void SetView(LandmineView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnDespawnLandmine, OnEnemyHit);
        }

        private void OnDespawnLandmine()
        {
            _objectPool.DespawnObject(_view.gameObject);
        }

        private void OnEnemyHit(EnemyView enemy)
        {
            enemy.OnTakeDamage?.Invoke(_objectPool.Model.ObjectDamage);
            Debug.Log(_objectPool.Model.ObjectDamage);
            OnDespawnLandmine();
        }
    }

}


