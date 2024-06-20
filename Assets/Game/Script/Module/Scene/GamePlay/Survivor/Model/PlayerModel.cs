using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Player {
    public class PlayerModel : BaseModel, IPlayerModel
    {
        public int Health { get; private set; }
        public int Experience { get; private set; }
        public int Level { get; private set; } = 1;
        public float Speed { get; private set; } = 5f;
        public float MagnetRange { get; private set; } = 10f;

        public void TakeDamage(int damage) 
        {
            Health -= damage;
            SetDataAsDirty();
        }

        public void AddExperience(int exp) {
            Experience += exp;
            SetDataAsDirty();
        }

        public void SubstractExperience(int exp)
        {
            Experience -= exp;
            SetDataAsDirty();
        }

        public void AddSpeed(int value) {
            Speed += value;
            SetDataAsDirty();
        }

        public void LevelUp() {
            Level++;
            SetDataAsDirty();
        }

    }

}
