using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Exp 
{
    public class ExpOrbPoolModel : BaseModel, IExpOrbPoolModel
    {
        public GameObject ExpOrbPrefab { get; private set; }
        public int PoolSize { get; private set; } = 300;

        private List<GameObject> ExpOrbPool = new List<GameObject>();

        public void SetExpOrbPrefab(GameObject expOrb) {
            ExpOrbPrefab = expOrb;
            SetDataAsDirty();
        }

        public void AddExpOrb(GameObject expOrb)
        {
            ExpOrbPool.Add(expOrb);
            SetDataAsDirty();
        }

        public void RemoveExpOrb(GameObject expOrb)
        {
            ExpOrbPool.Remove(expOrb);
            SetDataAsDirty();
        }

        public GameObject GetExpOrbInFront()
        {
            if (ExpOrbPool.Count > 0)
            {
                return ExpOrbPool[0];
            }

            return null;
        }
    }

}

