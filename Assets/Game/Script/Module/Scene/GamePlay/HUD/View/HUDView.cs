using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using Agate.MVC.Base;
using Roguelike.Module.Weapon;

namespace Roguelike.Module.HUD {
    public class HUDView : ObjectView<IHUDModel>
    {
        [SerializeField]
        public Image _expBar; 
        [SerializeField]
        private TextMeshProUGUI _lvl;
        [SerializeField]
        private TextMeshProUGUI _time;
        /*       [SerializeField]
                 private Button _gamePauseButton;*/
        [SerializeField]
        public GameObject _gameOverPanel;
        [SerializeField]
        private Button _mainMenuButton;

        public GameObject powerUpPanel;

        public GameObject powerUpCardPrefab;
    
        private UnityAction _timer;

        public void SetCallbacks(UnityAction timer, UnityAction onGamePause, UnityAction onGoToMainMenu)
        {
            _timer = timer;
            /* _gamePauseButton.onClick.AddListener(onGamePause);*/
            _mainMenuButton.onClick.AddListener(onGoToMainMenu);
        }

        protected override void InitRenderModel(IHUDModel model)
        {
            _expBar.fillAmount = 0f;
            _lvl.text = $"Lvl. {model.Level}";
            _time.text = string.Format("00:00");
        }

        protected override void UpdateRenderModel(IHUDModel model)
        {
            int minutes = Mathf.FloorToInt(model.Time / 60f);
            int seconds = Mathf.FloorToInt(model.Time % 60f);

            _time.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            _lvl.text = $"Lvl. {model.Level}";
            
        }

        private void Update()
        {
            _timer?.Invoke();  
        }

    }
}

