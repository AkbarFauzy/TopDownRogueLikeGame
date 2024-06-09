using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.HUD 
{
    public class HUDConnector : BaseConnector
    {
        private HUDController _hud;
        protected override void Connect()
        {
            Subscribe<PlayerLevelUpMessage>(_hud.OnPlayerLevelUp);
        }

        protected override void Disconnect()
        {
            Unsubscribe<PlayerLevelUpMessage>(_hud.OnPlayerLevelUp);
        }
    }
}

