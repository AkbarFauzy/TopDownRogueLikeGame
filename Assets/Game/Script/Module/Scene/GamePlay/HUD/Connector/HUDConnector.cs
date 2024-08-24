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
            Subscribe<ShowPowerUpOptionsMessage>(_hud.OnShowPowerUpOptions);
            Subscribe<PowerUpSelectionMessage>(_hud.OnPowerUpSelection);
            Subscribe<GameOverMessage>(_hud.OnGameOver);
        }

        protected override void Disconnect()
        {
            Unsubscribe<PlayerGainingExperience>(_hud.OnPlayerGainingExp);
            Unsubscribe<PlayerLevelUpMessage>(_hud.OnPlayerLevelUp);
            Unsubscribe<ShowPowerUpOptionsMessage>(_hud.OnShowPowerUpOptions);
            Unsubscribe<PowerUpSelectionMessage>(_hud.OnPowerUpSelection);
            Unsubscribe<GameOverMessage>(_hud.OnGameOver);
        }
    }
}

