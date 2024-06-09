using UnityEngine;

namespace Roguelike.Message
{
    public struct EnemyMoveMessage
    {
        public Transform Direction { get; }
        public EnemyMoveMessage(Transform direction)
        {
            Direction = direction;
        }

    }

}