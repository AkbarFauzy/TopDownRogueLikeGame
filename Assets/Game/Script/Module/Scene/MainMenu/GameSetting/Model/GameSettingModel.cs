using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.GameSetting 
{
    public class GameSettingModel : BaseModel, IGameSettingModel
    {
        public bool IsSfxOn { get; private set; }
        public bool IsBgmOn { get; private set; }

        public void SetSfx(bool isSfxOn)
        {
            IsSfxOn = isSfxOn;
            SetDataAsDirty();
        }
        public void SetBgm(bool isBgmOn)
        {
            IsBgmOn = isBgmOn;
            SetDataAsDirty();
        }
    }
}


