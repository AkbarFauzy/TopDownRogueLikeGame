using UnityEngine;
using Roguelike.Utility;
                     

namespace Roguelike.Module.Weapon
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
    public class WeaponScriptableObject : ScriptableObject
    {
        public Sprite Icon;
        public string WeaponDescription;
        public int NumberOfInstance;
        public float Damage;
        public float Multiplier;
        public float WeaponSize;
    }

}

