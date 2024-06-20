using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Enemy
{
    public interface IEnemyModel : IBaseModel
    {
        public Vector3 Position { get;}
        public int Health { get; }
        public float Speed { get; }
        public int Damage { get; }
        public Transform PlayerPosition { get; }
    }
}
