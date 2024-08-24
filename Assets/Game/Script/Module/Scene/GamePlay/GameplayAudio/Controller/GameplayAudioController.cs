using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;
using Roguelike.Module.ConfigData;

namespace Roguelike.Module.GameplayAudio {
    public class GameplayAudioController : ObjectController<GameplayAudioController, GameplayAudioModel, IGameplayAudioModel, GameplayAudioView> 
    {
        private ConfigDataController _configData;

        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
            _model.SetIsMuted(!_configData.Model.IsSfxOn);
        }

        public void OnUpdateSfxConfig(UpdateSfxConfigMessage message)
        {
            _model.SetIsMuted(!message.IsSfxOn);
        }

        public void OnGameOver(GameOverMessage message)
        {
            _view.PlayGameOverSfx();
        }

        public void OnPlayerLevelUp(PlayerLevelUpMessage message)
        {
            _view.PlayLevelUpSfx();
        }

        public void OnPlay(GamePlayStartMessage message)
        {
            _view.PlayBGMSfx();
        }
    }
}


