using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.Exp 
{

    public class ExpOrbPoolConnector : BaseConnector
    {
        private ExpOrbPoolController _expOrbPool;
        protected override void Connect()
        {
            Subscribe<PickupExpOrbMessage>(_expOrbPool.OnPickupExpOrb);
            Subscribe<EnemyDefeatedMessage>(_expOrbPool.SpawnExpOrb);
        }

        protected override void Disconnect()
        {
            Unsubscribe<PickupExpOrbMessage>(_expOrbPool.OnPickupExpOrb);
            Unsubscribe<EnemyDefeatedMessage>(_expOrbPool.SpawnExpOrb);
        }

    }
}

