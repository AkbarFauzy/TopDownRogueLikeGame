using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Utility;

namespace Roguelike.Module.Weapon 
{
    public class WeaponModel : BaseModel, IWeaponModel
    {
        public Sprite Icon { get; private set; }
        public WeaponName WeaponName { get; private set; }
        public WeaponType WeaponType { get; private set; }
        public string WeaponDescription { get; private set; }
        public float Damage { get; private set; }
        public float Multiplier { get; private set; }
        public int WeaponLevel { get; private set; }
        public Transform Player { get; private set; } = GameObject.FindGameObjectWithTag("Player").transform;
        private List<WeaponScriptableObject> _stats = new List<WeaponScriptableObject>();
        public string NextLevelDescription { get => _stats[WeaponLevel].WeaponDescription; }
        public WeaponScriptableObject CurrentStat => (WeaponLevel >= 1 && WeaponLevel <= _stats.Count) ? _stats[WeaponLevel-1] : _stats[WeaponLevel];
        public bool IsMaxLevel => WeaponLevel >= _stats.Count;

        public void SetIcon(Sprite icon)
        {
            Icon = icon;
            SetDataAsDirty();
        }

        public void SetWeaponName (WeaponName name){
            WeaponName = name;
            SetDataAsDirty();
        }

        public void SetWeaponType(WeaponType type) {
            WeaponType = type;
            SetDataAsDirty();
        }

        public void SetWeaponDescription(string description) {
            WeaponDescription = description;
            SetDataAsDirty();
        }

        public void SetDamage(float damage) {
            Damage = damage;
            SetDataAsDirty();
        }

        public void SetMultiplier(float multiplier) {
            Multiplier = multiplier;
            SetDataAsDirty();
        }

        public void LevelUpWeapon(){
            WeaponLevel += 1;
            InitStats();
            SetDataAsDirty();
        }

        public void SetStats(List<WeaponScriptableObject> stats) {
            _stats = stats;
            SetDataAsDirty();
        }

        public void InitStats()
        {
            SetIcon(CurrentStat.Icon);
            SetDamage(CurrentStat.Damage);
            SetWeaponDescription(CurrentStat.WeaponDescription);
            SetMultiplier(CurrentStat.Multiplier);
        }
    }

}

