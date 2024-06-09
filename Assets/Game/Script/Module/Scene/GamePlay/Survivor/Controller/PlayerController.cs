using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.Player
{
    public class PlayerController : ObjectController<PlayerController, PlayerModel, IPlayerModel, PlayerView>
    {
        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }
        
        public override void SetView(PlayerView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnCollideWithEnemy, OnTriggerItem);
        }

        public void OnMovePlayer(MovePlayerMessage message)
        {
            Vector2 direction = message.Direction;
            _view.rbody.velocity = direction * _model.Speed;
        }

        private void OnCollideWithEnemy() {
            Publish<PlayerTakeDamageMessage>(new PlayerTakeDamageMessage());
        }

        private void OnTriggerItem(GameObject triggeredItem) {
            Publish<TriggerItemMessage>(new TriggerItemMessage(triggeredItem));
        }

    }

}
