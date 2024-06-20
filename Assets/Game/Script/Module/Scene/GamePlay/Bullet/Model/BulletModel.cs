using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Bullet {
    public class BulletModel : BaseModel, IBulletModel
    {
        public int Damage { get; private set; } = 1;

        public float Force { get; private set; } = 10f;
    }
} 


