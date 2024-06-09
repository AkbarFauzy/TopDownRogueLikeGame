using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Module.Enemy;
using Roguelike.Message;


namespace Roguelike.Module.EnemySpawner {
    public class EnemySpawnerController : ObjectController<EnemySpawnerController, EnemySpawnerModel, IEnemySpawnerModel, EnemySpawnerView>
    {
        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }
        public override void SetView(EnemySpawnerView view)
        {
            base.SetView(view);
            InitPoolObject();
/*            view.SetCallbacks(OnMoveEnemy);*/
        }

        private void InitPoolObject()
        {
            _model.SetEnemyPrefab(_view.EnemyPrefab);
            for (int i = 0; i < _model.PoolSize; i++)
            {
                GameObject enemyPrefab = _model.EnemyPrefab;
                GameObject enemy = Object.Instantiate(enemyPrefab, _view.transform);
                SpawnEnemy(enemy);
            }
        }

        private void SpawnEnemy(GameObject enemy)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(_model.MinXSpawnPoint, _model.MaxXSpawnPoint) ,Random.Range(_model.MinYSpawnPoint, _model.MaxYSpawnPoint));
            enemy.transform.localPosition = _model.SpawnPoint + spawnPosition;
            /*_model.MoveSpawnPoint();*/
            enemy.SetActive(true);
            _model.EnqueueEnemy(enemy);

        }

        public void OnGameOver(GameOverMessage message)
        {

        }


    }
}

