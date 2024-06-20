using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Module.Player;
using Roguelike.Module.Bullet;
using Roguelike.Module.Exp;
using Roguelike.Module.EnemySpawner;
using Roguelike.Module.HUD;
using Roguelike.Module.GameplayCamera;

namespace Roguelike.Scene.Gameplay {
    public class GameplayView : BaseSceneView
    {
        [SerializeField]
        public HUDView HUDView;
        [SerializeField]
        public CameraView CameraView;
        [SerializeField]
        public PlayerView PlayerView;
        [SerializeField]
        public EnemySpawnerView EnemySpawnerView;
        [SerializeField]
        public BulletPoolView BulletPoolView;
        [SerializeField]
        public ExpOrbPoolView ExpOrbPoolView;
        [SerializeField]
        public LevelManagerView LevelManagerView;
        
    }
}

