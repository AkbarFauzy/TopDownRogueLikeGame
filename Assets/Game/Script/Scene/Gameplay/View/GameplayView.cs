using UnityEngine;
using Agate.MVC.Base;
using Roguelike.Module.Player;
using Roguelike.Module.Bullet;
using Roguelike.Module.EnemySpawner;

namespace Roguelike.Scene.Gameplay {
    public class GameplayView : BaseSceneView
    {
        [SerializeField]
        public PlayerView PlayerView;
        [SerializeField]
        public EnemySpawnerView EnemySpawnerView;
        [SerializeField]
        public BulletView BulletView;
    }
}

