using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.HUD 
{
    public class HUDController : ObjectController<HUDController, HUDModel, IHUDModel, HUDView>
    {
        public override void SetView(HUDView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnGamePause);
        }

        public void OnPlayerLevelUp(PlayerLevelUpMessage message) {
        
        
        }

        public void OnGamePause() {
            Publish<ShowGamePauseMessage>(new ShowGamePauseMessage());
        }

    }
}

