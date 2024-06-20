using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;

namespace Roguelike.Module.GameplayCamera
{
    public class CameraView : ObjectView<ICameraModel>
    {
        public Collider2D Bounds;
        public Transform Target;

        private UnityAction _onCameraMove;

        public void SetCallbacks(UnityAction onCameraMove)
        {
            _onCameraMove = onCameraMove;
        }

        protected override void InitRenderModel(ICameraModel model)
        {
           
        }

        protected override void UpdateRenderModel(ICameraModel model)
        {
            transform.position = _model.TargetPosition;
        }

        private void Update()
        {
            _onCameraMove?.Invoke();
        }

    }
}


