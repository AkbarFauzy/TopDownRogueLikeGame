using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.Exp 
{
    public class ExpOrbController : ObjectController<ExpOrbController, ExpOrbModel, IExpOrbModel, ExpOrbView>
    {

        public void Init(ExpOrbModel model, ExpOrbView view) {
            _model = model;
            SetView(view);
        }

        public override void SetView(ExpOrbView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnMagnetRange, OnAttractPlayer, OnPickupByPlayer);
        }

        public void OnAttractPlayer()
        {
            if (_model.Player != null)
            {
                _view.transform.position = Vector2.MoveTowards(_view.transform.position, _model.Player.position, 5f * Time.deltaTime);
            }
        }

        private void OnMagnetRange(Transform playerTransform)
        {
            _model.SetPlayer(playerTransform);
        }

        private void OnPickupByPlayer() {
            Publish<PickupExpOrbMessage>(new PickupExpOrbMessage(_view.gameObject, _model.Experience));
        }

    }

}
