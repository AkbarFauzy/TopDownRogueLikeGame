using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;


namespace Roguelike.Module.HUD 
{
    public class HUDModel : BaseModel, IHUDModel
    {
        public float Exp {get; private set;}
        public int Level { get; private set; }
        public int Time { get; private set; }


        private void AddExp(float exp) {
            Exp += exp;
            SetDataAsDirty();
        }

        private void AddLevel(int lvl)
        {
            Level += lvl;
            SetDataAsDirty();
        }

        private void SetTime(int time)
        {
            Time = time;
            SetDataAsDirty();
        }

    }

}

