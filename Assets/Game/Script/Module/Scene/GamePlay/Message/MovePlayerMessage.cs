using UnityEngine;

namespace Roguelike.Message
{
    public struct MovePlayerMessage
    {
        public Vector2 Direction { get; }
        public MovePlayerMessage(Vector2 direction)
        {
            Direction = direction;
        }

    }
}

