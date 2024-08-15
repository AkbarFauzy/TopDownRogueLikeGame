using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;
using Roguelike.Module.Bullet;

namespace Roguelike.Module.Enemy 
{
    public class EnemyView : ObjectView<IEnemyModel>
    {
        public Rigidbody2D rbody;


        public UnityAction<float> OnTakeDamage;
        private UnityAction<Transform> _onMovePosition;
        private UnityAction _onDamagingPlayer;

        public void SetCallbacks(UnityAction<float> onTakeDamage, UnityAction<Transform> onMovePosition, UnityAction onDamagingPlayer)
        {
            OnTakeDamage = onTakeDamage;
            _onMovePosition = onMovePosition;
            _onDamagingPlayer = onDamagingPlayer;
        }

        protected override void InitRenderModel(IEnemyModel model)
        {
            /*transform.position = _model.Position;*/
        }

        protected override void UpdateRenderModel(IEnemyModel model)
        {
            /*transform.position = _model.Position;*/
        }


        private void Update()
        {
            _onMovePosition?.Invoke(_model.PlayerPosition);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                _onDamagingPlayer?.Invoke();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) {
                _onDamagingPlayer?.Invoke();
            }
        }

    }
}

