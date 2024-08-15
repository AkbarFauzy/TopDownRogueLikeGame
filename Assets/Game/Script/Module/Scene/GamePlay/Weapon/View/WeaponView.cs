using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;
using Roguelike.Module.Enemy;
using Roguelike.Utility;

namespace Roguelike.Module.Weapon
{
    public class WeaponView : ObjectView<IWeaponModel>
    {
        public WeaponName WeaponName;
        public WeaponType WeaponType;
        public List<WeaponScriptableObject> Stats = new List<WeaponScriptableObject>();
        private UnityAction<EnemyView> _onCollideWithEnemy;

        public void SetCallbacks(UnityAction<EnemyView> onCollideWithEnemy)
        {
            _onCollideWithEnemy = onCollideWithEnemy;
        }

        protected override void InitRenderModel(IWeaponModel model)
        {

        }

        protected override void UpdateRenderModel(IWeaponModel model)
        {
            
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                _onCollideWithEnemy?.Invoke(collision.gameObject.GetComponent<EnemyView>());
            }
        }

    }
}


