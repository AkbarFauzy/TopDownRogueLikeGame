using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Exp 
{
    public interface IExpOrbPoolModel : IBaseModel
    {
        public int PoolSize { get; }
                              
    }
}

