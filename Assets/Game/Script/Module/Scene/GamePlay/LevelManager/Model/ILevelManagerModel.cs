using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Exp 
{
    public interface ILevelManagerModel : IBaseModel
    {
        public int BaseXP { get; }

    }
}

