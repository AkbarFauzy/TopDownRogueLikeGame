using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Obstacle
{
    public class ObstacleModel : BaseModel, IObstacleModel
    {
        public float CurrentTime { get; private set; }
        public float DesignatedTime { get; private set; }
        public bool IsSpawnAtPlayer { get; private set; }
        public float Damage { get; private set; } = 2f;

        public void AddCurrentTime()
        {
            CurrentTime += Time.deltaTime;
            SetDataAsDirty();
        }

        public void ResetCurrentTime()
        {
            CurrentTime = 0f;
            SetDataAsDirty();
        }
        public void SetDesignatedTime(float time)
        {
            DesignatedTime = time;
            SetDataAsDirty();
        }

        public void SetIsSpawnAtPlayer(bool isSpawnAtPlayer) {
            IsSpawnAtPlayer = isSpawnAtPlayer;
            SetDataAsDirty();
        }
    }
}

