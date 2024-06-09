using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Bullet 
{
    public class BulletModel : BaseModel, IBulletModel
    {
        public GameObject BulletPrefab { get; private set; }
        public int PoolSize { get; private set; } = 3;
        public Transform SpawnPoint { get; private set; } = GameObject.FindGameObjectWithTag("Player").transform;
        public Vector3 DespawnPosition { get; private set; } = new Vector3(10f, 10f, 10f);
        public Vector3 Position { get; private set; }


        private Queue<GameObject> BulletPool = new Queue<GameObject>();
        public void SetBulletPrefab(GameObject prefab)
        {
           BulletPrefab = prefab;
        }

        public void EnqueueBullet(GameObject obstacle)
        {
            BulletPool.Enqueue(obstacle);
            SetDataAsDirty();
        }

        public GameObject DequeueObstacle()
        {
            return BulletPool.Dequeue();
        }

        public GameObject GetObstacleInFront()
        {
            return BulletPool.Peek();
        }

    }

}
