using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Utility;

namespace Roguelike.Module.Weapon 
{
    public class WeaponManagerModel : BaseModel, IWeaponManagerModel
    {
        public List<WeaponController> AvailableWeapon { get; private set; } = new List<WeaponController>();
        public Dictionary<WeaponName, WeaponController> ActiveWeapons { get; private set; } = new Dictionary<WeaponName, WeaponController>();

        public void AddAvailableWeapon(WeaponController weapon)
        {
            AvailableWeapon.Add(weapon);
            SetDataAsDirty();
        }
        public void RemoveAvailableWeapon(WeaponController weapon) {
            AvailableWeapon.Remove(weapon);
            SetDataAsDirty();
        }

        public void AddWeapon(WeaponController weapon) {
            ActiveWeapons[weapon.Model.WeaponName] = weapon;
            SetDataAsDirty();
        }


    }
}

