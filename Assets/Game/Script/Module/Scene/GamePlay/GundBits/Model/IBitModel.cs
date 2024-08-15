using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Weapon {
    public interface IBitModel : IBaseModel
    {
        public Vector2 TargetPosition { get; }
        public float TargetRotation { get; }
    }
}


