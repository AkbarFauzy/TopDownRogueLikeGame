using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Module.Menu;
using Roguelike.Module.GameSetting;

namespace Roguelike.Scene.MainMenu
{
    public class MainMenuView : BaseSceneView
    {
        [SerializeField]
        public MenuView MenuView;
        [SerializeField]
        public GameSettingView GameSettingView;
    }

}
