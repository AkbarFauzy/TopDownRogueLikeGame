using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;
using Roguelike.Module.Bullet;

namespace Roguelike.Module.Enemy 
{
    public class EnemyView : ObjectView<IEnemyModel>
    {
        [SerializeField]
        public Rigidbody2D rbody;

        public UnityAction<int> OnTakeDamage;
        private UnityAction<Transform> _onMovePosition;

        public void SetCallbacks(UnityAction<int> onTakeDamage, UnityAction<Transform> onMovePosition)
        {
            OnTakeDamage = onTakeDamage;
            _onMovePosition = onMovePosition;
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
    }
}

