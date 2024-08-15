using Agate.MVC.Base;

namespace Roguelike.Module.Player
{
    public interface IPlayerModel : IBaseModel
    {
        public float CurrentHealth { get; }
        public float MaxHealth { get; }
        public float Speed { get; }
        public int Experience { get; } 
        public int Level { get; }

    }
}
