using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.Bullet 
{
    public class BulletController : ObjectController<BulletController, BulletModel, IBulletModel, BulletView>
    {
        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }

        public override void SetView(BulletView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnMovePosition, OnDespawnBullet);
            InitPoolBullet();
        }

        public void InitPoolBullet()
        {
            _model.SetBulletPrefab(_view.BulletPrefab);
            for (int i = 0; i < _model.PoolSize; i++)
            {
                GameObject bulletPrefab = _model.BulletPrefab;
                GameObject bullet = Object.Instantiate(bulletPrefab, _view.transform);
                SpawnBullet(bullet);
            }  
        }

        public void SpawnBullet(GameObject bullet) {
            bullet.transform.localPosition = _model.SpawnPoint.position;
            bullet.SetActive(true);
            _model.EnqueueBullet(bullet);
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3 direction = mousePosition - _view.transform.position;
            direction.z = 0f; 
            bullet.GetComponent<Rigidbody2D>().AddForce(direction * 10f, ForceMode2D.Impulse);
        }

        private void OnMovePosition(Vector3 cursorPosition)
        {
  /*          Vector3 pos = Vector3.MoveTowards(_model.PlayerPosition.position, 
                new Vector3(20f, 20f, 20f), 
                1f);
            Debug.Log(pos);*/
     /*       _model.SetPosition(pos);*/
        }

        private void OnDespawnBullet()
        {
            float frontBulletXPosition = _model.GetObstacleInFront().transform.position.x;
            float frontBulletYPosition = _model.GetObstacleInFront().transform.position.y;
            bool isDespawn = frontBulletXPosition >= _model.DespawnPosition.x ||
                frontBulletXPosition <= -_model.DespawnPosition.x ||
                frontBulletYPosition >= _model.DespawnPosition.y ||
                frontBulletYPosition <= -_model.DespawnPosition.y;
            Debug.Log(isDespawn);
            if (isDespawn)
            {
                GameObject bullet = _model.DequeueObstacle();
                bullet.SetActive(false);
                SpawnBullet(bullet);
            }
        }

        public void OnCollideWithEnemy() { 
        
        }

        public void OnGameOver(GameOverMessage message) { 
        
        
        }

    }
}


