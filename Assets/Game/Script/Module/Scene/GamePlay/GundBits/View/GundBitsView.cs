using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;

namespace Roguelike.Module.Weapon {
    public class GundBitsView : ObjectView<IGundBitsModel>
    {
        public GameObject BitPrefab;
        protected override void InitRenderModel(IGundBitsModel model)
        {
            
        }

        protected override void UpdateRenderModel(IGundBitsModel model)
        {

        }
    }
}


