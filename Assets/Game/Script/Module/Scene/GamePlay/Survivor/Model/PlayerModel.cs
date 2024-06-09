using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Player {
    public class PlayerModel : BaseModel, IPlayerModel
    {
        public int Health { get; private set; }
        public int Score { get; private set; }
        public float Speed { get; private set; } = 5f;

        public void TakeDamage(int damage) 
        {
            Health -= damage;
            SetDataAsDirty();
        }

        public void AddScore(int point) {
            Score += point;
            SetDataAsDirty();
        }

        public void AddSpeed(int value) {
            Speed += value;
            SetDataAsDirty();
        }

    }

}
