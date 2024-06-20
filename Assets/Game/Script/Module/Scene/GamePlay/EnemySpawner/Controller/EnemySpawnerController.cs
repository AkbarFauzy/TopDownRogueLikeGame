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
        }

        private void InitPoolObject()
        {
            _model.SetEnemyPrefab(_view.EnemyPrefab);
            for (int i = 0; i < _model.PoolSize; i++)
            {
                GameObject enemyPrefab = _model.EnemyPrefab;
                EnemyModel enemyModel = new EnemyModel();
                GameObject enemy = Object.Instantiate(enemyPrefab, _view.transform);
                EnemyView enemyView = enemy.GetComponent<EnemyView>();
                EnemyController enemyController = new EnemyController();
                InjectDependencies(enemyController);
                enemyController.Init(enemyModel, enemyView);
                SpawnEnemy(enemy);
            }
        }
        Vector2 GenerateRandomSpawnPosition()
        {
            float randomX = Random.Range(0, 2) == 0
                ? Random.Range(_model.MinXSpawnPoint, _model.MaxXSpawnPoint)
                : Random.Range(-_model.MaxXSpawnPoint, -_model.MinXSpawnPoint);

            float randomY = Random.Range(0, 2) == 0
                ? Random.Range(_model.MinYSpawnPoint, _model.MaxYSpawnPoint)
                : Random.Range(-_model.MaxYSpawnPoint, -_model.MinYSpawnPoint);

            return new Vector2(randomX, randomY);
        }


        private void SpawnEnemy(GameObject enemy)
        {
            Vector2 spawnPosition = GenerateRandomSpawnPosition();
            enemy.transform.localPosition = _model.SpawnPoint + spawnPosition;
            enemy.SetActive(true);
            _model.AddEnemy(enemy);
        }

        public void OnEnemyDied(EnemyDefeatedMessage message) {
            GameObject enemy = message.Enemy;
            _model.RemoveEnemy(enemy);
            enemy.SetActive(false);
            SpawnEnemy(enemy);
        }

        public void OnGameOver(GameOverMessage message)
        {

        }

    }
}

