using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.Enemy {
    public class EnemyController : ObjectController<EnemyController, EnemyModel, IEnemyModel, EnemyView>
    {
        public override IEnumerator Finalize()
        {
            yield return base.Finalize();
        }
        public override void SetView(EnemyView view)
        {
            base.SetView(view);
            view.SetCallbacks(OnMoveEnemy);
        }

        public void OnMoveEnemy(Transform playerPosition)
        {
            Vector3 pos = Vector3.MoveTowards(_view.transform.position, playerPosition.position, _model.Speed * Time.deltaTime);
            _view.rbody.MovePosition(pos);
        }

        public void OnGameOver(GameOverMessage message)
        {

        }
    }
}


