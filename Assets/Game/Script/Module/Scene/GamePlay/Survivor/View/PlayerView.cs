using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;
using UnityEngine.UI;

namespace Roguelike.Module.Player {
    public class PlayerView : ObjectView<IPlayerModel>
    {
        private UnityAction<GameObject> _onTriggerWithItem;
        [SerializeField] private Image HealthBar;

        public void SetCallbacks(UnityAction<GameObject> onTriggerWithItem)
        {
            _onTriggerWithItem = onTriggerWithItem;
        }

        protected override void InitRenderModel(IPlayerModel model)
        {
            HealthBar.fillAmount = _model.CurrentHealth / _model.MaxHealth;
        }

        protected override void UpdateRenderModel(IPlayerModel model)
        {
            HealthBar.fillAmount = _model.CurrentHealth / _model.MaxHealth;
        }

    }

}

