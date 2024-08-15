using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Roguelike.Message {
    public struct PlayerTakeDamageMessage
    {
        public float Damage { get; private set; }
        public PlayerTakeDamageMessage(float damage)
        {
            Damage = damage;
        }
    }
}
