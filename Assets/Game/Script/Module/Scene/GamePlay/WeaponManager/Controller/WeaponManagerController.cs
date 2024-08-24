using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;
using Roguelike.Utility;

namespace Roguelike.Module.Weapon {
    public class WeaponManagerController : ObjectController<WeaponManagerController, WeaponManagerModel, IWeaponManagerModel, WeaponManagerView>
    {
        public override void SetView(WeaponManagerView view)
        {
            base.SetView(view);
            InitAvailableWeapon();
        }

        public void InitAvailableWeapon()
        {
            foreach (var _weapon in _view.WeaponsPrefabs) {
                GameObject weapon = Object.Instantiate(_weapon, _view.transform);
                WeaponView weaponView = weapon.GetComponent<WeaponView>();
                WeaponModel weaponModel = new WeaponModel();
                WeaponController weaponController = new WeaponController();

                InjectDependencies(weaponController);
                weaponController.Init(weaponModel, weaponView);
                _model.AddAvailableWeapon(weaponController);
                if (weaponController.Model.WeaponName == WeaponName.DefaultWeapon)
                {
                    _model.AddWeapon(weaponController);
                    weaponController.Activate();
                }

            }
        }

        public WeaponController[] GenerateRandomWeaponSelection() {
            int count = 3;
            List<WeaponController> _availableWeapon = new List<WeaponController>(_model.AvailableWeapon);
            WeaponController[] chosenWeapons = new WeaponController[count];
            for (int i =0; i<count;i++) {

                if (_availableWeapon.Count == 0) break;

                int selectedWeaponIndex = Random.Range(0, _availableWeapon.Count);
                chosenWeapons[i] = _availableWeapon[selectedWeaponIndex];
                _availableWeapon.RemoveAt(selectedWeaponIndex);
            }

            return chosenWeapons;
        }

        public void OnShowPowerUpOptions(ShowPowerUpOptionsMessage message) {
            var selectedWeapons = GenerateRandomWeaponSelection();
            Publish<PowerUpSelectionMessage>(new PowerUpSelectionMessage(selectedWeapons));
        }

        public void UpdateWeapons(PowerUpSelectedMessage message) {
            var weaponName = message.PowerUp.Model.WeaponName;
            if (_model.ActiveWeapons.ContainsKey(weaponName))
            {
                var weapon = _model.ActiveWeapons[weaponName];
                weapon.LevelUpWeapon();
                if (weapon.Model.IsMaxLevel)
                {
                    _model.RemoveAvailableWeapon(weapon);
                }
            }
            else {
                _model.AddWeapon(message.PowerUp);
                message.PowerUp.Activate();
            }
        }
    }
}


