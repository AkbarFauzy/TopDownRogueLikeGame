using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.Obstacle {
    public class ObstacleController : ObjectController<ObstacleController, ObstacleModel, IObstacleModel, ObstacleView>
    {
        Transform PlayerPosition;
        Transform[] child;
        public void Init(ObstacleModel model, ObstacleView view)
        {
            _model = model;
            SetView(view);
            PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public override void SetView(ObstacleView view)
        {
            base.SetView(view);
            child = _view.gameObject.GetComponentsInChildren<Transform>();
            foreach (var obj in child) {
                obj.gameObject.SetActive(false);
            }

            _view.SetCallbacks(OnTimer, OnDamagingPlayer);
        }

        private void OnTimer() {
            _model.AddCurrentTime();
            if (_model.CurrentTime > _model.DesignatedTime) {
                if (_model.IsSpawnAtPlayer)
                {
                    _view.gameObject.transform.position = PlayerPosition.position;
                }

                foreach (var obj in child)
                {
                    obj.gameObject.SetActive(true);
                }
                _model.ResetCurrentTime();
            }
        }

        private void OnDamagingPlayer()
        {
            Publish<PlayerTakeDamageMessage>(new PlayerTakeDamageMessage(_model.Damage));
        }

    }
}


