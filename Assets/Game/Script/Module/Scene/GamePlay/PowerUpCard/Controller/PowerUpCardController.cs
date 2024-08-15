using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;
using Roguelike.Module.Weapon;

namespace Roguelike.Module.HUD 
{
    public class PowerUpCardController : ObjectController<PowerUpCardController, PowerUpCardModel, IPowerUpCardModel,PowerUpCardView>
    {
        public void Init(PowerUpCardModel model, PowerUpCardView view) {
            _model = model;
            SetView(view);
        }

        public override void SetView(PowerUpCardView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnClickCard);
        }

        public void UpdateCard(WeaponController weapon) {
            var model = weapon.Model;
            _model.SetWeapon(weapon);
            _model.SetIcon(model.Icon);
            _model.SetName(model.WeaponName);
            _model.SetDescription(model.NextLevelDescription);
            _view.gameObject.SetActive(true);
            _view.Icon.sprite = _model.Icon;
            _view.NameText.text = _model.Name.ToString();
            _view.DescriptionText.text = _model.Description;
        }

        public void OnClickCard()
        {
            Publish<PowerUpSelectedMessage>(new PowerUpSelectedMessage(_model.PowerUpController));
            Publish<ShowPowerUpOptionsMessage>(new ShowPowerUpOptionsMessage());
        }

    }
}


