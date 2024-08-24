using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;


namespace Roguelike.Module.GameplayAudio {
    public class GameplayAudioModel : BaseModel, IGameplayAudioModel
    {
        public bool IsMuted { get; private set; }

        public void SetIsMuted(bool isMuted)
        {
            IsMuted = isMuted;
            SetDataAsDirty();
        }
    }
}

