using UnityEngine;

namespace Roguelike.Message
{
    public struct EnemyDefeatedMessage
    {
        public GameObject Enemy { get; private set; }
        public float ExpOrbCount { get; private set; }
        public bool IsRespawn { get; private set; }
        public Vector2 LastPosition { get; private set; }

        public EnemyDefeatedMessage(GameObject enemy, float expOrbCount, bool isRespawn = false)
        {
            Enemy = enemy;
            IsRespawn = isRespawn;
            ExpOrbCount = expOrbCount;
            LastPosition = enemy.transform.position;
        }

    }

}

