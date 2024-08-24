using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Agate.MVC.Base;
using Roguelike.Module.Weapon;

namespace Roguelike.Module.HUD 
{
    public class HUDModel : BaseModel, IHUDModel
    {
        public int Level { get; private set; }
        public float Time { get; private set; }
        public List<PowerUpCardController> PowerUpCards { get; private set; } = new List<PowerUpCardController>();

        public void SetLevel(int lvl)
        {
            Level = lvl;
            SetDataAsDirty();
        }

        public void AddTime(float time)
        {
            Time += time;
            SetDataAsDirty();
        }
    }

}

