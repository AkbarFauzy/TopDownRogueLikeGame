using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;
using Roguelike.Utility;
using Roguelike.Boot;

namespace Roguelike.Module.HUD 
{
    public class HUDController : ObjectController<HUDController, HUDModel, IHUDModel, HUDView>
    {
        public override void SetView(HUDView view)
        {
            base.SetView(view);
            view.SetCallbacks(PlayTimer, OnGamePause, OnGoToMainMenu);
        }

        public void OnPlayerLevelUp(PlayerLevelUpMessage message) {
            _model.SetLevel(message.Level);
        }

        public void OnPlayerGainingExp(PlayerGainingExperience message) {
            _view._expBar.fillAmount = (float)message.Exp / (float)message.MaxExp;
        }

        private void PlayTimer() {
            _model.AddTime(Time.deltaTime);
            Debug.Log(_model.Time);
        }

        public void OnGamePause() {
            Publish<ShowGamePauseMessage>(new ShowGamePauseMessage());
        }

        public void OnGameOver(GameOverMessage message)
        {
            _view._gameOverPanel.SetActive(true);
        }

        public void OnGoToMainMenu() {
            SceneLoader.Instance.LoadScene(GameScene.MainMenu);
        }

    }
}

