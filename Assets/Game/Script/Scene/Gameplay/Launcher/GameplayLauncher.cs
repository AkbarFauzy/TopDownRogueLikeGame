using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Roguelike.Boot;
using Roguelike.Utility;
using Roguelike.Module.Input;
using Roguelike.Module.Player;
using Roguelike.Module.Bullet;
using Roguelike.Module.Exp;
using Roguelike.Module.EnemySpawner;
using Roguelike.Module.HUD;
using Roguelike.Module.GameplayCamera;



namespace Roguelike.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {

        private PlayerController _player;
        private BulletPoolController _bullet;
        private EnemySpawnerController _enemySpawner;
        private ExpOrbPoolController _expOrbPool;
        private LevelManagerController _levelManager;
        private HUDController _hud;
        private CameraController _camera;

        public override string SceneName { get { return GameScene.GamePlay; } }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
               new InputConnector(),
               new PlayerConnector(),
               new BulletPoolConnector(),
               new EnemySpawnerConnector(),
               new ExpOrbPoolConnector(),
               new HUDConnector(),
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
               new InputController(),
               new PlayerController(),
               new BulletPoolController(),
               new EnemySpawnerController(),
               new ExpOrbPoolController(),
               new LevelManagerController(),
               new HUDController(),
               new CameraController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _player.SetView(_view.PlayerView);
            _enemySpawner.SetView(_view.EnemySpawnerView);
            _bullet.SetView(_view.BulletPoolView);
            _expOrbPool.SetView(_view.ExpOrbPoolView);
            _levelManager.SetView(_view.LevelManagerView);
            _hud.SetView(_view.HUDView);
            _camera.SetView(_view.CameraView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}
