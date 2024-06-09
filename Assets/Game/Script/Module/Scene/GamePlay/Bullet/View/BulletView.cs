using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Agate.MVC.Base;


namespace Roguelike.Module.Bullet
{
    public class BulletView : ObjectView<IBulletModel>
    {
        public Camera MainCamera;
        public GameObject BulletPrefab;
        private UnityAction<Vector3> _onMovePosition;
        private UnityAction _onDespawnBullet;

        public void SetCallbacks(UnityAction<Vector3> onMovePosition, UnityAction onDespawnBullet)
        {
            _onMovePosition = onMovePosition;
            _onDespawnBullet = onDespawnBullet;
        }


        protected override void InitRenderModel(IBulletModel model)
        {
            transform.position = _model.Position;
        }

        protected override void UpdateRenderModel(IBulletModel model)
        {
            transform.position = _model.Position;
        }

        private void Update()
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();

            Vector3 worldMousePosition = MainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, MainCamera.nearClipPlane));

            _onMovePosition?.Invoke(MainCamera.ScreenToWorldPoint(worldMousePosition));
            _onDespawnBullet?.Invoke();
        }

    }
}

