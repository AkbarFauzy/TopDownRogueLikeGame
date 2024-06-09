using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using Agate.MVC.Base;

namespace Roguelike.Module.HUD {
    public class HUDView : ObjectView<IHUDModel>
    {
        [SerializeField]
        private Image _expBar; 
        [SerializeField]
        private TextMeshProUGUI _lvl;
        [SerializeField]
        private TextMeshProUGUI _time;
        [SerializeField]
        private Button _gamePauseButton;


        protected override void InitRenderModel(IHUDModel model)
        {
          
        }

        protected override void UpdateRenderModel(IHUDModel model)
        {
            
        }

        public void SetCallbacks(UnityAction onGamePause)
        {
            _gamePauseButton.onClick.AddListener(onGamePause);

        }

    }
}

