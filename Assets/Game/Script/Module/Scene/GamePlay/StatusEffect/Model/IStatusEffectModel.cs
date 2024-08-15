using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.StatusEffect
{
  public interface IStatusEffectModel : IBaseModel
  {
        public string EffectName { get; }
        public string Description { get; }
        public StatusEffectTypes EffectType { get; }
        public float Modifier { get; }

        public abstract void ApplyEffect(GameObject target);
        public abstract void RemoveEffect(GameObject target);

  }
}



