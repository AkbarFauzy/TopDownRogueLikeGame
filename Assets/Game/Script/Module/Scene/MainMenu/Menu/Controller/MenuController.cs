using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Boot;
using Roguelike.Utility;
using Roguelike.Message;


namespace Roguelike.Module.Menu
{
    public class MenuController : ObjectController<MenuController, MenuView>
    {
        public override void SetView(MenuView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnPlay, OnShowSetting, OnExit);
        }

        private void OnPlay()
        {
            SceneLoader.Instance.LoadScene(GameScene.GamePlay);
        }

        private void OnShowSetting()
        {
            Publish<ShowSettingMessage>(new ShowSettingMessage());
        }

        private void OnExit()
        {
            Application.Quit();
        }
    }
}
