using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Utility;
using Roguelike.Module.Weapon;

namespace Roguelike.Module.HUD 
{
    public class PowerUpCardModel : BaseModel, IPowerUpCardModel
    {
        public WeaponController PowerUpController {get; private set;}

        public Sprite Icon { get; private set; }

        public WeaponName Name { get; private set; }

        public string Description { get; private set; }

        public void SetWeapon(WeaponController powerUpController) {
            PowerUpController = powerUpController;
            SetDataAsDirty();
        }

        public void SetIcon(Sprite icon) {
            Icon = icon;
            SetDataAsDirty();
        }

        public void SetName(WeaponName name) {
            Name = name;
            SetDataAsDirty();
        }

        public void SetDescription(string description)
        {
            Description = description;
            SetDataAsDirty();
        }
    }

}

