using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.Exp 
{
    public class ExpOrbPoolController : ObjectController<ExpOrbPoolController, ExpOrbPoolModel, IExpOrbPoolModel, ExpOrbPoolView>
    {

        public void InitPoolObject()
        {
            _model.SetExpOrbPrefab(_view.expOrbPrefab);
            for (int i = 0; i < _model.PoolSize; i++)
            {
                GameObject expOrbPrefab = _model.ExpOrbPrefab;
                ExpOrbModel expOrbModel = new ExpOrbModel();
                GameObject expOrb = Object.Instantiate(expOrbPrefab, _view.transform);
                ExpOrbView expOrbView = expOrb.GetComponent<ExpOrbView>();
                ExpOrbController expOrbController = new ExpOrbController();

                InjectDependencies(expOrbController);
                expOrbController.Init(expOrbModel, expOrbView);
                expOrb.SetActive(false);
                _model.AddExpOrb(expOrb);
            }

        }

        public override void SetView(ExpOrbPoolView view)
        {
            base.SetView(view);
            InitPoolObject();
           /* view.SetCallbacks(OnDespawnExpOrb, OnPickupExpOrb);*/
        }


/*        private void OnDespawnExpOrb() {
            GameObject expOrb = _model.GetExpOrbInFront();
            //make a condition if exceed limit
            DespawnExpOrb(expOrb);
        }*/

        public void OnPickupExpOrb(PickupExpOrbMessage message) {
            ReturnExpOrbToPool(message.ExpOrb);
        }

        public void SpawnExpOrb(EnemyDefeatedMessage message)
        {
            Vector2 enemyPosition = message.LastPosition;
            GameObject expOrb = _model.GetExpOrbInFront();

            expOrb.transform.position = enemyPosition;
            expOrb.SetActive(true);
            _model.RemoveExpOrb(expOrb);
            _model.AddExpOrb(expOrb);
        }

        private void ReturnExpOrbToPool(GameObject expOrb)
        {
            expOrb.SetActive(false);
            _model.RemoveExpOrb(expOrb);
            _model.AddExpOrb(expOrb);
        }

/*        private void DespawnExpOrb(GameObject expOrb) {
            expOrb.SetActive(false); 
        }*/

    }
}



