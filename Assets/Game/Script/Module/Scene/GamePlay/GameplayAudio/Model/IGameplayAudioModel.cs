using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

namespace Roguelike.Module.GameplayAudio {
    public interface IGameplayAudioModel : IBaseModel
    {
        public bool IsMuted { get; }
    }
}

