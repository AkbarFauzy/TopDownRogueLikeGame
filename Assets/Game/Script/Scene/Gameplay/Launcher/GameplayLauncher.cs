using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Roguelike.Boot;
using Roguelike.Utility;
using Roguelike.Module.Input;
using Roguelike.Module.Player;
using Roguelike.Module.Bullet;
using Roguelike.Module.EnemySpawner;


namespace Roguelike.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {

        private PlayerController _player;
        private BulletController _bullet;
        private EnemySpawnerController _enemySpawner;

        public override string SceneName { get { return GameScene.GamePlay; } }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
               new InputConnector(),
               new PlayerConnector(),
               new BulletConnector(),
               new EnemySpawnerConnector(),
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
               new InputController(),
               new PlayerController(),
               new BulletController(),
               new EnemySpawnerController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _player.SetView(_view.PlayerView);
            _enemySpawner.SetView(_view.EnemySpawnerView);
            _bullet.SetView(_view.BulletView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}
