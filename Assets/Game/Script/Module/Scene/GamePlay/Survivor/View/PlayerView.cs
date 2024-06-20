using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;



namespace Roguelike.Module.Player {
    public class PlayerView : ObjectView<IPlayerModel>
    {
        public Rigidbody2D rbody;
        private UnityAction _onCollideWithEnemy;
        private UnityAction<GameObject> _onTriggerWithItem;

        public void SetCallbacks(UnityAction onCollideWithEnemy, UnityAction<GameObject> onTriggerWithItem)
        {
            _onCollideWithEnemy = onCollideWithEnemy;
            _onTriggerWithItem = onTriggerWithItem;
        }

        protected override void InitRenderModel(IPlayerModel model)
        {
            
        }

        protected override void UpdateRenderModel(IPlayerModel model)
        {
           
        }

        private void OnCollisionEnter2D(Collision2D collisionInfo)
        {
            if (collisionInfo.gameObject.CompareTag("Enemy"))
            {
                _onCollideWithEnemy?.Invoke();
            }
        }
    }

}

