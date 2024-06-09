using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.HUD 
{
    public interface IHUDModel : IBaseModel
    {
        public float Exp { get; }
        public int Level { get; }
        public int Time { get; }
    }

}

