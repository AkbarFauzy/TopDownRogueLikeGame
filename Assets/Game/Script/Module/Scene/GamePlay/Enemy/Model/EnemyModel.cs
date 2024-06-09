using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Enemy 
{
    public class EnemyModel : BaseModel, IEnemyModel
    {
        public Vector3 Position { get; private set; }
        public int Health { get; private set; }
        public float Speed { get; private set; } = 3f;
        public int Damage  { get; private set; }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            SetDataAsDirty();
        }

        public void AddDamage(int value)
        {
            Damage += value;
            SetDataAsDirty();
        }

        public void AddSpeed(int value)
        {
            Speed += value;
            SetDataAsDirty();
        }

    }

}


