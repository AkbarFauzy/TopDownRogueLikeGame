using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using Agate.MVC.Base;
using Roguelike.Module.Enemy;


namespace Roguelike.Module.Bullet
{
    public class BulletPoolView : ObjectView<IBulletPoolModel>
    {
        public GameObject BulletPrefab;

        protected override void InitRenderModel(IBulletPoolModel model)
        {
            /*transform.position = _model.Position;*/
        }

        protected override void UpdateRenderModel(IBulletPoolModel model)
        {
           /* transform.position = _model.Position;*/
        }

    }
}

