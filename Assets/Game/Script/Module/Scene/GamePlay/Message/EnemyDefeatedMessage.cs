using UnityEngine;

namespace Roguelike.Message
{
    public struct EnemyDefeatedMessage
    {
        public GameObject Enemy { get; private set; }
        public Vector2 LastPosition { get; private set; }

        public EnemyDefeatedMessage(GameObject enemy)
        {
            Enemy = enemy;
            LastPosition = enemy.transform.position;
        }

    }

}

