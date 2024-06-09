using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.GameSetting
{
    public class GameSettingConnector : BaseConnector
    {
        private GameSettingController _gameSetting;
        protected override void Connect()
        {
            Subscribe<ShowSettingMessage>(_gameSetting.OnShowSetting);
        }

        protected override void Disconnect()
        {
            Unsubscribe<ShowSettingMessage>(_gameSetting.OnShowSetting);
        }
    }

}
