using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Utility;
using Roguelike.Module.Weapon;

namespace Roguelike.Module.HUD {
    public interface IPowerUpCardModel : IBaseModel
    {
        public WeaponController PowerUpController { get; }
        public Sprite Icon { get; }
        public WeaponName Name { get; }
        public string Description { get; }
    }

}

