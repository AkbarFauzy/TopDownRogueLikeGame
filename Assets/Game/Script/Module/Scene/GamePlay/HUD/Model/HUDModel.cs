using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;


namespace Roguelike.Module.HUD 
{
    public class HUDModel : BaseModel, IHUDModel
    {
        public int Level { get; private set; }
        public float Time { get; private set; }

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

