using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

namespace Roguelike.Module.Bullet 
{
    public interface IBulletPoolModel : IBaseModel
    {
        public float BulletDamage { get;}
        public int PoolSize { get; }
        public Transform SpawnPoint { get;}
        public Vector3 DespawnPosition { get; }
    }

}
