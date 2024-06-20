using System.Collections;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;
using Roguelike.Module.Exp;

namespace Roguelike.Module.Player
{
    public class PlayerController : ObjectController<PlayerController, PlayerModel, IPlayerModel, PlayerView>
    {
        private LevelManagerController _levelManager;

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

        public void OnPickupExp(PickupExpOrbMessage message)
        {
            _model.AddExperience(message.Experience);
            Debug.Log("Orb Collected Current Exp: "+_model.Experience);
            while (_model.Experience >= _levelManager.GetXPForLevel(_model.Level)) {
                _model.SubstractExperience(_levelManager.GetXPForLevel(_model.Level));
                _model.LevelUp();
                Publish<PlayerLevelUpMessage>(new PlayerLevelUpMessage(_model.Level));
            }
            Publish<PlayerGainingExperience>(new PlayerGainingExperience(_model.Experience, _levelManager.GetXPForLevel(_model.Level)));
        }

        private void OnCollideWithEnemy() {
            /*Publish<PlayerTakeDamageMessage>(new PlayerTakeDamageMessage());*/
            Publish<GameOverMessage>(new GameOverMessage());
        }

        private void OnTriggerItem(GameObject triggeredItem) {
            Publish<TriggerItemMessage>(new TriggerItemMessage(triggeredItem));
        }

    }

}
