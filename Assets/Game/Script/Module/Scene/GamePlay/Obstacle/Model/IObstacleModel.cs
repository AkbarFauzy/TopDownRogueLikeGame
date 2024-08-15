using Agate.MVC.Base;

namespace Roguelike.Module.Obstacle
{
    public interface IObstacleModel : IBaseModel
    {
        public float CurrentTime { get; }
        public float DesignatedTime { get; }
        public bool IsSpawnAtPlayer { get; }
        public float Damage { get; }
    }
}

