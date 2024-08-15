using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Enemy
{
    public interface IEnemyModel : IBaseModel
    {
        public Vector3 Position { get;}
        public float Health { get; }
        public int Exp { get; }
        public float Speed { get; }
        public float Damage { get; }
        public bool IsRespawn { get; }
        public Transform PlayerPosition { get; }
    }
}
