using Agate.MVC.Base;
using Roguelike.Message;

namespace Roguelike.Module.EnemySpawner
{
    public class EnemySpawnerConnector : BaseConnector
    {
        private EnemySpawnerController _enemySpawner;

        protected override void Connect()
        {
            Subscribe<GameOverMessage>(_enemySpawner.OnGameOver);
        }

        protected override void Disconnect()
        {
            Unsubscribe<GameOverMessage>(_enemySpawner.OnGameOver);
        }
    }
}
