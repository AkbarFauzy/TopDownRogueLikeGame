using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.Enemy 
{
    public class EnemyConnector : BaseConnector
    {
        private EnemyController _enemy;

        protected override void Connect() {
            Subscribe<GameOverMessage>(_enemy.OnGameOver);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameOverMessage>(_enemy.OnGameOver);
        }
    }
}


