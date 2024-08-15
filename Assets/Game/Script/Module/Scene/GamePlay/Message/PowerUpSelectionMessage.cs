using Roguelike.Module.Weapon;

namespace Roguelike.Message 
{
    public struct PowerUpSelectionMessage
    {
        public WeaponController[] PowerUpSelection { get; }

        public PowerUpSelectionMessage(WeaponController[] powerUpSelection)
        {
            PowerUpSelection = powerUpSelection;
        }

    }
}


