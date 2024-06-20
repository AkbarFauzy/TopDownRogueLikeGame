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

 /*       private UnityAction _onDespawnExpOrb;
        private UnityAction<GameObject> _onPickupExpOrb;

        public void SetCallbacks(UnityAction onDespawnExpOrb, UnityAction<GameObject> onPickupExpOrb)
        {
            _onDespawnExpOrb = onDespawnExpOrb;
            _onPickupExpOrb = onPickupExpOrb;
        }*/



        protected override void InitRenderModel(IExpOrbPoolModel model)
        {
            
        }

        protected override void UpdateRenderModel(IExpOrbPoolModel model)
        {
       
        }



    }
}


