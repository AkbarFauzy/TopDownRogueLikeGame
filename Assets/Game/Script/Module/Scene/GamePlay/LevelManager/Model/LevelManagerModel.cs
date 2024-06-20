using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Exp 
{
    public class LevelManagerModel :BaseModel, ILevelManagerModel
    {
        public int BaseXP { get; private set; } = 10;
        public void SetBaseXP (int baseExp){
            BaseXP = baseExp;
            SetDataAsDirty();
        }
    }
}

