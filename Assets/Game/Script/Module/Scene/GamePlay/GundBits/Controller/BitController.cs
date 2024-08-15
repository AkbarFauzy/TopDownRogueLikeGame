using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Weapon {
    public class BitController : ObjectController<BitController, BitModel, IBitModel, BitView>
    {
        private Animator _anim;

        public void Init(BitModel model, BitView view)
        {
            SetView(view);
            _model = model;
            _anim = _view.gameObject.GetComponent<Animator>();
        }

        public override void SetView(BitView view)
        {
            base.SetView(view);
            _view.SetCallbacks(OnEnable);
        }

        void SetRandomPositionAndRotation()
        {
            float randomDistance = Random.Range(2f, 10f);
            float randomAngle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
            Vector2 offset = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)) * randomDistance;
            _model.SetTargetPosition((Vector2)_model.Player.transform.position + offset);
            _model.SetTargetRotation(Random.Range(0f, 360f));
        }

        private void MoveTowardsTarget()
        {
            _view.transform.position = Vector2.MoveTowards(_view.transform.position, _model.TargetPosition, 20f * Time.deltaTime);
        }

        void RotateTowardsTarget()
        {
            Quaternion targetRotationQuat = Quaternion.Euler(new Vector3(0, 0, _model.TargetRotation));
            _view.transform.rotation = Quaternion.RotateTowards(_view.transform.rotation, targetRotationQuat, 100f * Time.deltaTime);
        }

        public void OnEnable() {
            _view.StartCoroutine(BehaviorLoop());
        }

        private IEnumerator BehaviorLoop() {
            while (_view.isActiveAndEnabled) {
                SetRandomPositionAndRotation();
                while (Vector2.Distance(_view.transform.position, _model.TargetPosition) > 0.1f 
                    || Quaternion.Angle(_view.transform.rotation, Quaternion.Euler(0, 0, _model.TargetRotation)) > 0.1f)
                {
                    MoveTowardsTarget();
                    RotateTowardsTarget();
                    yield return null;
                }
                _anim.SetTrigger("Trigger");
                yield return new WaitForSeconds(_anim.GetCurrentAnimatorStateInfo(0).length);
            }

            yield return null;
        }

    }
}

