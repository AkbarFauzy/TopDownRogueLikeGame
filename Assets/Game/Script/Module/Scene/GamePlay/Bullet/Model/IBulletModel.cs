using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Bullet 
{
    public interface IBulletModel : IBaseModel
    {
        public int Damage { get; }
        public float Force { get; }

    }
}
