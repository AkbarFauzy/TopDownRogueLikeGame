using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Utility;

namespace Roguelike.Module.Weapon {
    public interface IWeaponModel : IBaseModel
    {
        public Sprite Icon { get; }
        public WeaponName WeaponName { get; }
        public WeaponType WeaponType { get; }
        public string WeaponDescription { get; }
        public string NextLevelDescription { get; }
        public int WeaponLevel { get; }
        public float Damage { get; }
        public float Multiplier { get; }
        public WeaponScriptableObject CurrentStat { get; }
        public bool IsMaxLevel { get; }
        void LevelUpWeapon();
    }
}


