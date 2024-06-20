using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Exp 
{
    public class LevelManagerController : ObjectController<LevelManagerController, LevelManagerModel, ILevelManagerModel, LevelManagerView>
    {
        public override void SetView(LevelManagerView view)
        {
            base.SetView(view);
        }

        public int GetXPForLevel(int level) {
            return _model.BaseXP * (level* (level + 1)) / 2;
        }    

    }
}

