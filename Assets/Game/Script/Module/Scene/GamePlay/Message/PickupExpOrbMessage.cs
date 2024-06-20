using UnityEngine;
namespace Roguelike.Message 
{
    public struct PickupExpOrbMessage
    {
        public GameObject ExpOrb { get; private set; }
        public int Experience { get; private set; }
        public PickupExpOrbMessage(GameObject expOrb, int experience){
            ExpOrb = expOrb;
            Experience = experience;
        }
    }

}
