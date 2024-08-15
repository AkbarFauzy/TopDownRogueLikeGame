using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Module.Weapon;

namespace Roguelike.Module.Bullet 
{
    public class BulletPoolController : ObjectController<BulletPoolController, BulletPoolModel, IBulletPoolModel, BulletPoolView>
    {
        private WeaponController _weaponController;

        public void Init(BulletPoolModel model, BulletPoolView view, WeaponController weaponController)
        {
            _model = model;
            _weaponController = weaponController;
            _model.SetBulletDamage(_weaponController.Model.CurrentStat.Damage); 
            SetView(view);
        }

        public override void SetView(BulletPoolView view)
        {
            base.SetView(view);
            InitPoolBullet();
            _view.SetCallbacks(OnSpawnBullet);
        }

        public void InitPoolBullet()
        {
            _model.SetBulletPrefab(_view.BulletPrefab);
            for (int i = 0; i < _model.PoolSize; i++)
            {
                GameObject bulletPrefab = _model.BulletPrefab;
                GameObject bullet = Object.Instantiate(bulletPrefab, _view.transform);
                BulletView bulletView = bullet.GetComponent<BulletView>();
                BulletController bulletController = new BulletController();
                InjectDependencies(bulletController);
                bulletController.Init(bulletView, this);
                DespawnBullet(bullet);
            }
        }

        private void OnSpawnBullet()
        {
            switch (_weaponController.Model.WeaponLevel) {
                case 2:
                    _view.StartCoroutine(ConsecutiveShoot(3));
                    break;
                case 3:
                    _view.StartCoroutine(ConsecutiveShoot(5));
                    break;
                default:
                    SpawnBullet();
                    break;
            }
        }

        private IEnumerator ConsecutiveShoot(int bulletPerShoot) {
            for (int i = 0; i < bulletPerShoot; i++)
            {
                SpawnBullet();
                yield return new WaitForSeconds(0.2f);
            }
        }

        private void SpawnBullet() {
            GameObject bullet = _model.DequeueBullet();
            bullet.transform.localPosition = _model.SpawnPoint.position;
            bullet.SetActive(true);
        }

        public void DespawnBullet(GameObject bullet)
        { 
            bullet.SetActive(false);
            _model.EnqueueBullet(bullet);
        }

    }
}


