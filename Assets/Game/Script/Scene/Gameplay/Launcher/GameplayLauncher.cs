using System.Collections;
using Agate.MVC.Base;
using Agate.MVC.Core;
using Roguelike.Boot;
using Roguelike.Utility;
using Roguelike.Module.Input;
using Roguelike.Module.Player;
using Roguelike.Module.Exp;
using Roguelike.Module.HUD;
using Roguelike.Module.ObstacleSpawner;
using Roguelike.Module.EnemySpawner;
using Roguelike.Module.GameplayCamera;
using Roguelike.Module.GameplayAudio;
using Roguelike.Module.Weapon;



namespace Roguelike.Scene.Gameplay
{
    public class GameplayLauncher : SceneLauncher<GameplayLauncher, GameplayView>
    {
        private PlayerController _player;
        private EnemySpawnerController _enemySpawner;
        private ExpOrbPoolController _expOrbPool;
        private LevelManagerController _levelManager;
        private HUDController _hud;
        private CameraController _camera;
        private GameplayAudioController _audio;
        private WeaponManagerController _weaponManager;
        private ObstacleSpawnerController _obstacleSpawner;

        public override string SceneName { get { return GameScene.GamePlay; } }

        protected override IConnector[] GetSceneConnectors()
        {
            return new IConnector[] {
               new InputConnector(),
               new PlayerConnector(),
               new EnemySpawnerConnector(),
               new ExpOrbPoolConnector(),
               new HUDConnector(),
               new WeaponManagerConnector(),
               new GameplayAudioConnector(),
            };
        }

        protected override IController[] GetSceneDependencies()
        {
            return new IController[] {
               new InputController(),
               new PlayerController(),
               new ObstacleSpawnerController(),
               new EnemySpawnerController(),
               new ExpOrbPoolController(),
               new LevelManagerController(),
               new HUDController(),
               new CameraController(),
               new GameplayAudioController(),
               new WeaponManagerController(),
            };
        }

        protected override IEnumerator InitSceneObject()
        {
            _player.SetView(_view.PlayerView);
            _obstacleSpawner.SetView(_view.ObstacleSpawnerView);
            _enemySpawner.SetView(_view.EnemySpawnerView);
            _audio.SetView(_view.AudioView);
            _expOrbPool.SetView(_view.ExpOrbPoolView);
            _levelManager.SetView(_view.LevelManagerView);
            _hud.SetView(_view.HUDView);
            _camera.SetView(_view.CameraView);
            _weaponManager.SetView(_view.WeaponManagerView);
            yield return null;
        }

        protected override IEnumerator LaunchScene()
        {
            yield return null;
        }
    }
}
