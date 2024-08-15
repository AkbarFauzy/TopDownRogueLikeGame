using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Module.Weapon;

namespace Roguelike.Module.Bullet 
{
    public class BulletPoolModel : BaseModel, IBulletPoolModel
    {
        public float BulletDamage { get; private set; }
        public int PoolSize { get; private set; } = 15;
        public GameObject BulletPrefab { get; private set; }
        public Transform SpawnPoint { get; private set; } = GameObject.FindGameObjectWithTag("Player").transform;
        public Vector3 DespawnPosition { get; private set; } = new Vector3(25f, 25f, 25f);
        private List<GameObject> BulletPool = new List<GameObject>();

        public void SetBulletDamage(float damage)
        {
            BulletDamage = damage;
            SetDataAsDirty();
        }

        public void SetBulletPrefab(GameObject prefab)
        {
           BulletPrefab = prefab;
        }

        public void EnqueueBullet(GameObject bullet)
        {
            BulletPool.Add(bullet);
            SetDataAsDirty();
        }

        public GameObject DequeueBullet()
        {
            GameObject bullet = BulletPool[0];
            BulletPool.RemoveAt(0);
            SetDataAsDirty();
            return bullet;
        }

        public int GetCurrentPoolSize() {
            return BulletPool.Count;
        }

    }

}
