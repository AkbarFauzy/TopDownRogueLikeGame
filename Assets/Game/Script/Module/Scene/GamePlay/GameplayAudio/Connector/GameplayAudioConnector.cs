using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.GameplayAudio {
    public class GameplayAudioConnector : BaseConnector
    {
        private GameplayAudioController _audio;
        protected override void Connect()
        {
            Subscribe<UpdateSfxConfigMessage>(_audio.OnUpdateSfxConfig);
            Subscribe<GamePlayStartMessage>(_audio.OnPlay);
            Subscribe<PlayerLevelUpMessage>(_audio.OnPlayerLevelUp);
            Subscribe<GameOverMessage>(_audio.OnGameOver);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateSfxConfigMessage>(_audio.OnUpdateSfxConfig);
            Unsubscribe<GamePlayStartMessage>(_audio.OnPlay);
            Unsubscribe<PlayerLevelUpMessage>(_audio.OnPlayerLevelUp);
            Unsubscribe<GameOverMessage>(_audio.OnGameOver);
        }

    }
}

