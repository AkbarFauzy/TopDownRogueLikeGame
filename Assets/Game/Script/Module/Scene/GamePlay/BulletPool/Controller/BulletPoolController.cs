using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Agate.MVC.Base;
using Roguelike.Message;
using Roguelike.Module.Enemy;

namespace Roguelike.Module.Bullet 
{
    public class BulletPoolController : ObjectController<BulletPoolController, BulletPoolModel, IBulletPoolModel, BulletPoolView>
    {
        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }

        public override void SetView(BulletPoolView view)
        {
            base.SetView(view);
            InitPoolBullet();
        }

        public void InitPoolBullet()
        {
            _model.SetBulletPrefab(_view.BulletPrefab);
            for (int i = 0; i < _model.PoolSize; i++)
            {
                GameObject bulletPrefab = _model.BulletPrefab;
                BulletModel bulletModel = new BulletModel();
          
                GameObject bullet = Object.Instantiate(bulletPrefab, _view.transform);
                BulletView bulletView = bullet.GetComponent<BulletView>();
                BulletController bulletController = new BulletController();
                InjectDependencies(bulletController);
                bulletController.Init(bulletModel, bulletView);
                SpawnBullet(bullet);
            }  
        }

        public void SpawnBullet(GameObject bullet) {
            bullet.transform.localPosition = _model.SpawnPoint.position;
            bullet.SetActive(true);
            _model.EnqueueBullet(bullet);
/*            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3 direction = mousePosition - _view.transform.position;
            direction.z = 0f; */
        }


        public void OnGameOver(GameOverMessage message) { 
        
        
        }

    }
}


