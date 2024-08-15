using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Weapon
{
    public class BitModel : WeaponModel, IBitModel
    {
        public Vector2 TargetPosition { get; private set; }
        public float TargetRotation { get; private set; }
        public void SetTargetPosition(Vector2 targetPosition)
        {
            TargetPosition = targetPosition;
            SetDataAsDirty();
        }

        public void SetTargetRotation(float angle) {
            TargetRotation = angle;
            SetDataAsDirty();
        }

    }
}

