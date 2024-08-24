using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Module.Obstacle;

namespace Roguelike.Module.ObstacleSpawner {
    public class ObstacleSpawnerController : ObjectController<ObstacleSpawnerController, ObstacleSpawnerView>
    {
        private void Init() { 
            foreach(var obstacle in _view.Obstacles)
            {
                GameObject obstacleObject = Object.Instantiate(obstacle.ObstaclePrefab, _view.transform);
                ObstacleView obstacleView = obstacleObject.GetComponent<ObstacleView>();
                ObstacleController obstacleController = new ObstacleController();
                ObstacleModel obstacleModel = new ObstacleModel();
                obstacleModel.SetDesignatedTime(obstacle.DesignatedTime);
                obstacleModel.SetIsSpawnAtPlayer(obstacle.isSpawnAtPlayer);
                InjectDependencies(obstacleController);
                obstacleController.Init(obstacleModel, obstacleView);
                obstacleView.gameObject.SetActive(true);
            }
        }

        public override void SetView(ObstacleSpawnerView view)
        {
            base.SetView(view);
            Init();
        }

    }

}
