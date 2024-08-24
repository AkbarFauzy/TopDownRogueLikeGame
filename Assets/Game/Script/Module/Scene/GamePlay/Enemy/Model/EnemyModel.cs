using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Module.EnemySpawner;

namespace Roguelike.Module.Enemy 
{
    public class EnemyModel : BaseModel, IEnemyModel
    {
        public Vector3 Position { get; private set; }
        public float BaseHealth { get; private set; }
        public float Health { get; private set; }
        public int Exp { get; private set; }
        public float Speed { get; private set; } = 3f;
        public float Damage  { get; private set; }
        public bool IsRespawn { get; private set; }
        public Transform PlayerPosition { get; private set; } = GameObject.FindGameObjectWithTag("Player").transform;

        public void Init(EnemySpawnerScriptableObject stat) {
            SetHealth(stat.Health);
            SetDamage(stat.Damage);
            SetIsRespawn(stat.IsRespawn);
            SetExp(stat.Exp);
        }

        public void TakeDamage(float damage)
        {
            Health -= damage;
            SetDataAsDirty();
        }

        public void SetDamage(float damage)
        {
            Damage = damage;
            SetDataAsDirty();
        }


        public void AddDamage(float value)
        {
            Damage += value;
            SetDataAsDirty();
        }

        public void AddSpeed(int value)
        {
            Speed += value;
            SetDataAsDirty();
        }

        public void SetHealth(float health)
        {
            Health = health;
            BaseHealth = health;
            SetDataAsDirty();
        }

        public void ResetHealth() {
            Health = BaseHealth;
            SetDataAsDirty();
        }

        public void SetExp(int value) {
            Exp = value;
            SetDataAsDirty();
        }

        public void SetIsRespawn(bool isRespawn)
        {
            IsRespawn = isRespawn;
            SetDataAsDirty();
        }

    }

}


