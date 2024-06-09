using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.Bullet{
    public class BulletConnector : BaseConnector
    {
        private BulletController _bullet;

        protected override void Connect()
        {
            Subscribe<GameOverMessage>(_bullet.OnGameOver);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameOverMessage>(_bullet.OnGameOver);
        }
    }

}
