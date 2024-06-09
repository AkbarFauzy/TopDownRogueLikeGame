using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;
using Roguelike.Module.Player;

namespace Roguelike.Module.Enemy 
{
    public class EnemyView : ObjectView<IEnemyModel>
    {
        [SerializeField]
        public Rigidbody2D rbody;
        private Transform playerTransform;

        private UnityAction<Transform> _onMovePosition;
        private UnityAction _onCollideWithBullet;
        private EnemyController _controller = new EnemyController();


        public void SetCallbacks(UnityAction<Transform> onMovePosition)
        {
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
            _onMovePosition?.Invoke(playerTransform);
        }

        private void Start()
        {
            _controller.SetView(this);
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void OnCollisionEnter2D(Collision2D collisionInfo)
        {
            bool isCollideWithBullet = collisionInfo.gameObject.CompareTag("Bullet");
            if (isCollideWithBullet)
            {
                collisionInfo.gameObject.transform.position = new Vector3(50f,50f,50f);
                this.gameObject.transform.position = new Vector3(Random.Range(-20f, 20f), Random.Range(-20f, -20f));
            }
        }

    }
}

