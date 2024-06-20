using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.GameplayCamera
{
    public class CameraModel : BaseModel, ICameraModel
    {
        public Camera Camera { get; private set; } = Camera.main;

        public Bounds WorldBounds { get; private set; }
        public Bounds CameraBounds { get; private set; }

        public Vector3 TargetPosition { get; private set; }

        public void SetWorldBounds(Bounds bounds)
        {
            WorldBounds = bounds;
            SetDataAsDirty();
        }

        public void SetCameraBounds(Bounds bounds) { 
            CameraBounds = bounds;
            SetDataAsDirty();
        }

        public Vector3 GetCameraBounds()
        {
            return new Vector3(
                Mathf.Clamp(TargetPosition.x, CameraBounds.min.x, CameraBounds.max.x),
                Mathf.Clamp(TargetPosition.y, CameraBounds.min.y, CameraBounds.max.y),
                -1f
                );
        }

        public void SetTargetPosition(Vector3 targetPosition) {
            TargetPosition = targetPosition;
            SetDataAsDirty();
        }

        public void UpdateTargetPosition(Vector3 targetPosition) {
            SetTargetPosition(targetPosition);
            TargetPosition = GetCameraBounds();
            SetDataAsDirty();
        }

    }
}

