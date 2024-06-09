using UnityEngine;

namespace Roguelike.Message 
{
    public struct TriggerItemMessage 
    {
        public GameObject Item { get; private set; }
        public TriggerItemMessage(GameObject item)
        {
            Item = item;
        }
    }
}

