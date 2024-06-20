using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.Player 
{
    public class PlayerConnector : BaseConnector
    {
        private PlayerController _player;

        protected override void Connect()
        {
            Subscribe<PickupExpOrbMessage>(_player.OnPickupExp);
            Subscribe<MovePlayerMessage>(_player.OnMovePlayer);
        }

        protected override void Disconnect()
        {
            Unsubscribe<PickupExpOrbMessage>(_player.OnPickupExp);
            Unsubscribe<MovePlayerMessage>(_player.OnMovePlayer);
        }
    }
}

