using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;

namespace Roguelike.Module.Obstacle
{
    public class ObstacleView : ObjectView<IObstacleModel>
    {
        private UnityAction _onTimer;
        private UnityAction _onDamagingPlayer;

        public void SetCallbacks(UnityAction onTimer, UnityAction onDamagingPlayer)
        {
            _onTimer = onTimer;
            _onDamagingPlayer = onDamagingPlayer;
        }
        private void Update()
        {
            _onTimer?.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) {
                _onDamagingPlayer?.Invoke();
            }
        }

        protected override void InitRenderModel(IObstacleModel model)
        {

        }

        protected override void UpdateRenderModel(IObstacleModel model)
        {

        }
    }

}

