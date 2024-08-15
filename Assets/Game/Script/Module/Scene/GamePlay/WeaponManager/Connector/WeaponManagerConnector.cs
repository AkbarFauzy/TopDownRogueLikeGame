using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.Weapon 
{
    public class WeaponManagerConnector : BaseConnector
    {
        WeaponManagerController _weaponManager;

        protected override void Connect()
        {
            Subscribe<ShowPowerUpOptionsMessage>(_weaponManager.OnShowPowerUpOptions);
            Subscribe<PowerUpSelectedMessage>(_weaponManager.UpdateWeapons);
        }

        protected override void Disconnect()
        {
            Unsubscribe<ShowPowerUpOptionsMessage>(_weaponManager.OnShowPowerUpOptions);
            Unsubscribe<PowerUpSelectedMessage>(_weaponManager.UpdateWeapons);
        }
    }
}


