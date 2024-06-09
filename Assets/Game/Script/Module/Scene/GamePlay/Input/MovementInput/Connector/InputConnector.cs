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
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameOverMessage>(_input.OnGameOver);
        }


    }
}

