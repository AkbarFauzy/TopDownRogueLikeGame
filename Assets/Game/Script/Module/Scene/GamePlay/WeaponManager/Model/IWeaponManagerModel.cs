using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Utility;

namespace Roguelike.Module.Weapon 
{
    public interface IWeaponManagerModel : IBaseModel
    {
        public List<WeaponController> AvailableWeapon { get; }
        public Dictionary<WeaponName, WeaponController> ActiveWeapons { get;}

    }
}

