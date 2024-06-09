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
            bool isCollideWithEnemy = collisionInfo.gameObject.CompareTag("Enemy");
            if (isCollideWithEnemy)
            {
                GetComponent<CircleCollider2D>().enabled = false;
                _onCollideWithEnemy?.Invoke();
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            bool isItem = other.gameObject.CompareTag("Item");
            if (isItem)
            {
                _onTriggerWithItem?.Invoke(other.gameObject);
            }
        }


    }

}

