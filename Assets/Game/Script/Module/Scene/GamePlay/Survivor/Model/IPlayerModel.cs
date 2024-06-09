using Agate.MVC.Base;

namespace Roguelike.Module.Player
{
    public interface IPlayerModel : IBaseModel
    {
        public int Health { get; }
        public float Speed { get; }
        public int Score { get; }

    }
}
