using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Exp 
{
    public interface IExpOrbModel : IBaseModel
    {
        public Transform Player { get; }
        public int Experience { get; }

    }
}


