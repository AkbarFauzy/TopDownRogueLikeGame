using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;

namespace Roguelike.Module.Exp 
{
    public class ExpOrbView : ObjectView<IExpOrbModel>
    {
        private UnityAction<Transform> _onMagnetRange;
        private UnityAction _onAttrackPlayer;
        private UnityAction _onPickupByPlayer;

        public void SetCallbacks(UnityAction<Transform> onMagnetRange, UnityAction onAttrackPlayer, UnityAction onPickupByPlayer)
        {
            _onMagnetRange = onMagnetRange;
            _onAttrackPlayer = onAttrackPlayer;
            _onPickupByPlayer = onPickupByPlayer;
        }

        protected override void InitRenderModel(IExpOrbModel model)
        {
          
        }

        protected override void UpdateRenderModel(IExpOrbModel model)
        {
        
        }

        private void Update()
        {
            _onAttrackPlayer?.Invoke();
        }

        private void OnCollisionEnter2D(Collision2D collisionInfo)
        {
          
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _onPickupByPlayer?.Invoke();
            }
            if (other.CompareTag("Magnet"))
            {
                _onMagnetRange?.Invoke(other.gameObject.transform);
            }
        }

    }
}


