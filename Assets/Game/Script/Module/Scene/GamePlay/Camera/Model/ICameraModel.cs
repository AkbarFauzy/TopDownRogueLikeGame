using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.GameplayCamera 
{
    public interface ICameraModel : IBaseModel
    {
        public Camera Camera { get; }
        public Bounds WorldBounds { get; }
        public Bounds CameraBounds { get; }
        public Vector3 TargetPosition { get; }

    }
}

