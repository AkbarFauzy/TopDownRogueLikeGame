using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Weapon
{
    public class GundBitsModel : BaseModel, IGundBitsModel
    {
        public int NumberOfBits { get; private set; } = 3;
        public Transform Player { get; private set; } = GameObject.FindGameObjectWithTag("Player").transform;

        public List<GameObject> Bits = new List<GameObject>();

        public void AddBit(GameObject bit)
        {
            Bits.Add(bit);
            SetDataAsDirty();
        }

        public void RemoveBit(GameObject bit)
        {
            Bits.Remove(bit);
            SetDataAsDirty();
        }


    }
}

