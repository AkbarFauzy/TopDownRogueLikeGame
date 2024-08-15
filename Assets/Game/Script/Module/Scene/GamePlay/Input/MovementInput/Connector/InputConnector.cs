using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.Input 
{
    public class InputConnector : BaseConnector
    {
        private InputController _input;
        protected override void Connect()
        {
            Subscribe<GameOverMessage>(_input.OnGameOver);
            Subscribe<OnGamePauseMessage>(_input.OnGamePause);
            Subscribe<OnGameResumeMessage>(_input.OnGameResume);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameOverMessage>(_input.OnGameOver);
            Unsubscribe<OnGamePauseMessage>(_input.OnGamePause);
            Unsubscribe<OnGameResumeMessage>(_input.OnGameResume);
        }


    }
}

