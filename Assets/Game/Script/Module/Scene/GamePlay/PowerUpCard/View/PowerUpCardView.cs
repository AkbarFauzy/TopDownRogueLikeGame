using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using Agate.MVC.Base;

namespace Roguelike.Module.HUD 
{
    public class PowerUpCardView : ObjectView<IPowerUpCardModel>
    {
        public Image Icon;
        public TextMeshProUGUI NameText;
        public TextMeshProUGUI DescriptionText;

        [SerializeField]
        private Button _button;

        public void SetCallbacks(UnityAction onClick) {
            _button.onClick.AddListener(onClick);     
        }

        protected override void InitRenderModel(IPowerUpCardModel model)
        {
            Icon.sprite = model.Icon;
            NameText.text = model.Name.ToString();
            DescriptionText.text = model.Description;
        }

        protected override void UpdateRenderModel(IPowerUpCardModel model)
        {
            Icon.sprite = model.Icon;
            NameText.text = model.Name.ToString();
            DescriptionText.text = model.Description;
        }

    }
}


