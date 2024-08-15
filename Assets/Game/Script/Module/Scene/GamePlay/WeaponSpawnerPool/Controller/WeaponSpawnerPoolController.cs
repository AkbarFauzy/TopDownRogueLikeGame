using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Utility;

namespace Roguelike.Module.Weapon { 
    public class WeaponSpawnerPoolController : ObjectController<WeaponSpawnerPoolController, WeaponSpawnerPoolModel, IWeaponSpawnerPoolModel, WeaponSpawnerPoolView>
    {
        private WeaponController _weaponController;

        public void Init(WeaponSpawnerPoolModel model, WeaponSpawnerPoolView view, WeaponController weaponController)
        {
            _model = model;
            _weaponController = weaponController;
            _model.SetObjectDamage(_weaponController.Model.CurrentStat.Damage);
            _model.SetPoolSize(_weaponController.Model.CurrentStat.NumberOfInstance);
            _model.SetObjectOnFieldCount(_weaponController.Model.CurrentStat.NumberOfInstance);
            SetView(view);
        }

        public override void SetView(WeaponSpawnerPoolView view)
        {
            base.SetView(view);
            InitPoolObject();
            _view.SetCallbacks(OnSpawnBullet);
        }

        public void InitPoolObject()
        {
            for (int i = 0; i < _model.PoolSize; i++)
            {
                GameObject objectPrefab = _view.ObjectPrefab;
                GameObject objectInstance = Object.Instantiate(objectPrefab, _view.transform);

                switch (_weaponController.Model.WeaponName)
                {
                    case WeaponName.LandMine:
                        LandmineView landmineView = objectInstance.GetComponent<LandmineView>();
                        LandmineController landmineController = new LandmineController();
                        InjectDependencies(landmineController);
                        landmineController.Init(landmineView, this);
                        break;
                    default:
                        break;
                }

                DespawnObject(objectInstance);
            }
        }

        private void OnSpawnBullet()
        {
            SpawnObject();
        }
/*
        private IEnumerator ConsecutiveShoot(int bulletPerShoot)
        {
            for (int i = 0; i < bulletPerShoot; i++)
            {
                SpawnBullet();
                yield return new WaitForSeconds(0.2f);
            }
        }
*/
        private void SpawnObject()
        {
            GameObject bullet = _model.DequeueBullet();
            bullet.transform.localPosition = _model.SpawnPoint.position;
            bullet.SetActive(true);
        }

        public void DespawnObject(GameObject bullet)
        {
            bullet.SetActive(false);
            _model.EnqueueBullet(bullet);
        }


    }
}

