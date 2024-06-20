using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Agate.MVC.Core;

namespace Roguelike.Module.Bullet 
{
    public interface IBulletPoolModel : IBaseModel
    {
/*        public Vector3 Position { get; }*/
        public Transform SpawnPoint { get;}
        public Vector3 DespawnPosition { get; }
    }

}
