using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;

namespace Roguelike.Module.Weapon 
{
    public class WeaponManagerView : ObjectView<IWeaponManagerModel>
    {
        public List<GameObject> WeaponsPrefabs;
        protected override void InitRenderModel(IWeaponManagerModel model)
        {
          
        }

        protected override void UpdateRenderModel(IWeaponManagerModel model)
        {
            
        }
    }
}

