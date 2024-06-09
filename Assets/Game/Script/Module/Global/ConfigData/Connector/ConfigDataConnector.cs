using Agate.MVC.Base;
using Roguelike.Message;


namespace Roguelike.Module.ConfigData 
{ 
    public class ConfigDataConnector : BaseConnector
    {
        private ConfigDataController _configData;
        protected override void Connect()
        {
            Subscribe<UpdateBgmConfigMessage>(_configData.SetBgm);
            Subscribe<UpdateSfxConfigMessage>(_configData.SetSfx);
        }

        protected override void Disconnect()
        {
            Unsubscribe<UpdateBgmConfigMessage>(_configData.SetBgm);
            Unsubscribe<UpdateSfxConfigMessage>(_configData.SetSfx);
        }
    }
}
