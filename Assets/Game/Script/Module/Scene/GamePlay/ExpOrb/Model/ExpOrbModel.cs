using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.Exp{
    public class ExpOrbModel : BaseModel, IExpOrbModel
    {
        public Transform Player { get; private set; }
        public int Experience { get; private set; } = 1;

        public void SetPlayer(Transform player) {
            Player = player;
            SetDataAsDirty();
        }

        public void SetExperience (int experience)
        {
            Experience = experience;
            SetDataAsDirty();
        }

    }
}


