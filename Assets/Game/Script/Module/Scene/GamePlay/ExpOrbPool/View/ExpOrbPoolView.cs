using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;

namespace Roguelike.Module.Exp
{
    public class ExpOrbPoolView : ObjectView<IExpOrbPoolModel>
    {
        public GameObject expOrbPrefab;

        protected override void InitRenderModel(IExpOrbPoolModel model)
        {
            
        }

        protected override void UpdateRenderModel(IExpOrbPoolModel model)
        {
       
        }
    }
}


