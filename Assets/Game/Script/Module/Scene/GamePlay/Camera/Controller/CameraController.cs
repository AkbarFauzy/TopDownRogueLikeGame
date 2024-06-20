using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.GameplayCamera 
{
    public class CameraController : ObjectController<CameraController, CameraModel, ICameraModel, CameraView>
    {
        public override void SetView(CameraView view)
        {
            base.SetView(view);
            _model.SetWorldBounds(_view.Bounds.bounds);
            _model.SetTargetPosition(_view.Target.position);
            
            var height = _model.Camera.orthographicSize;
            var width = height * _model.Camera.aspect;

            var minX = _model.WorldBounds.min.x + width;
            var minY = _model.WorldBounds.min.y + height;

            var maxX = _model.WorldBounds.max.x - width;
            var maxY = _model.WorldBounds.max.y - height;

            Bounds _cameraBounds = new Bounds();
            _cameraBounds.SetMinMax(
                    new Vector3(minX, minY, 0f),
                    new Vector3(maxX, maxY, 0f)
                );

            _model.SetCameraBounds(_cameraBounds);

            _view.SetCallbacks(OnCameraMove);

        }

        private void OnCameraMove() {
            _model.UpdateTargetPosition(_view.Target.position);
        }

    }
}


