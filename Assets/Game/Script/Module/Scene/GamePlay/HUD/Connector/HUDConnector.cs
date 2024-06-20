using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.HUD 
{
    public class HUDConnector : BaseConnector
    {
        private HUDController _hud;
        protected override void Connect()
        {
            Subscribe<PlayerGainingExperience>(_hud.OnPlayerGainingExp);
            Subscribe<PlayerLevelUpMessage>(_hud.OnPlayerLevelUp);
            Subscribe<GameOverMessage>(_hud.OnGameOver);
        }

        protected override void Disconnect()
        {
            Unsubscribe<PlayerGainingExperience>(_hud.OnPlayerGainingExp);
            Unsubscribe<PlayerLevelUpMessage>(_hud.OnPlayerLevelUp);
            Unsubscribe<GameOverMessage>(_hud.OnGameOver);
        }
    }
}

