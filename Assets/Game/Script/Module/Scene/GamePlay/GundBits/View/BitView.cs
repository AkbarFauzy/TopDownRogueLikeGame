using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;

namespace Roguelike.Module.Weapon {
    public class BitView : ObjectView<IBitModel>
    {
        private UnityAction _onEnable;

        public void SetCallbacks(UnityAction onEnable)
        {
            _onEnable = onEnable;
        }

        public void OnEnable()
        {
            _onEnable?.Invoke();
        }

        protected override void InitRenderModel(IBitModel model)
        {
          
        }

        protected override void UpdateRenderModel(IBitModel model)
        {
           
        }
    }
}

