using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Module.Player;
using Roguelike.Module.Bullet;
using Roguelike.Module.Exp;
using Roguelike.Module.HUD;
using Roguelike.Module.ObstacleSpawner;
using Roguelike.Module.EnemySpawner;
using Roguelike.Module.GameplayCamera;
using Roguelike.Module.GameplayAudio;
using Roguelike.Module.Weapon;

namespace Roguelike.Scene.Gameplay {
    public class GameplayView : BaseSceneView
    {
        [SerializeField]
        public HUDView HUDView;
        [SerializeField]
        public CameraView CameraView;
        [SerializeField]
        public GameplayAudioView AudioView;
        [SerializeField]
        public PlayerView PlayerView;
        [SerializeField]
        public EnemySpawnerView EnemySpawnerView;
        [SerializeField]
        public ExpOrbPoolView ExpOrbPoolView;
        [SerializeField]
        public LevelManagerView LevelManagerView;
        [SerializeField]
        public WeaponManagerView WeaponManagerView;
        [SerializeField]
        public ObstacleSpawnerView ObstacleSpawnerView;

    }
}

