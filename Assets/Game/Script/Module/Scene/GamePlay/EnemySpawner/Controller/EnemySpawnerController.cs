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
            _view.SetCallbacks(OnTimer);
            InitPoolObject();
        }

        private void InitPoolObject()
        {
            foreach (var _enemy in _view.Enemy) {
                List<GameObject> EnemyInWaiting = new List<GameObject>();
                for (int i = 0; i < _enemy.PoolSize; i++)
                {
                    GameObject enemyPrefab = _enemy.EnemyPrefab;
                    EnemyModel enemyModel = new EnemyModel();
                    GameObject enemy = Object.Instantiate(enemyPrefab, _view.transform);
                    EnemyView enemyView = enemy.GetComponent<EnemyView>();
                    EnemyController enemyController = new EnemyController();
                    InjectDependencies(enemyController);
                    enemyModel.Init(_enemy);
                    enemyController.Init(enemyModel, enemyView, this);
                    EnemyInWaiting.Add(enemy);
                    enemy.SetActive(false);
                }
                _view.StartCoroutine(WaitToSpawnEnemy(EnemyInWaiting, _enemy.SpawnAt));
            }
        }
        private IEnumerator WaitToSpawnEnemy(List<GameObject> enemies, float timeToWait) {
            yield return new WaitForSeconds(timeToWait);
            foreach (var enemy in enemies) {
                SpawnEnemy(enemy);
            }
            yield break;
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
            if (message.IsRespawn)
            {
                SpawnEnemy(enemy);
            }
        }

        public void OnTimer() {
            _model.AddTime();
        }

        public void OnGameOver(GameOverMessage message)
        {

        }


    }
}

