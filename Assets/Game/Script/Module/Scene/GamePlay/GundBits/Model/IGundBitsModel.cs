using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Weapon
{
    public interface IGundBitsModel : IBaseModel
    {
        public int NumberOfBits { get; }
    }

}
