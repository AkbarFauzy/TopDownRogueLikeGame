using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Weapon {
    public class WeaponSpawnerPoolModel : BaseModel, IWeaponSpawnerPoolModel
    {
        public float ObjectDamage { get; private set; }
        public int PoolSize { get; private set; }
        public int ObjectOnFieldCount { get; private set; }
        public Transform SpawnPoint { get; private set; } = GameObject.FindGameObjectWithTag("Player").transform;
        
        private List<GameObject> ObjectPool = new List<GameObject>();

        public void SetObjectDamage(float damage)
        {
            ObjectDamage = damage;
            SetDataAsDirty();
        }

        public void SetPoolSize(int size)
        {
            PoolSize = size;
            SetDataAsDirty();
        }

        public void SetObjectOnFieldCount(int number) {
            ObjectOnFieldCount = number;
            SetDataAsDirty();
        }

        public void EnqueueBullet(GameObject bullet)
        {
            ObjectPool.Add(bullet);
            ObjectOnFieldCount -= 1;
            SetDataAsDirty();
        }

        public GameObject DequeueBullet()
        {
            GameObject bullet = ObjectPool[0];
            ObjectPool.RemoveAt(0);
            ObjectOnFieldCount += 1;
            SetDataAsDirty();
            return bullet;
        }

        public int GetCurrentPoolSize()
        {
            return ObjectPool.Count;
        }


    }
}

