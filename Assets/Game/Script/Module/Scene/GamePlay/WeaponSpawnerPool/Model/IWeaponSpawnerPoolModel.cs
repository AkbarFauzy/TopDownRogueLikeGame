using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Weapon { 
    public interface IWeaponSpawnerPoolModel : IBaseModel
    {
        public float ObjectDamage { get; }
        public int PoolSize { get; }
        public int ObjectOnFieldCount { get; }
        public Transform SpawnPoint { get; }
    }
}