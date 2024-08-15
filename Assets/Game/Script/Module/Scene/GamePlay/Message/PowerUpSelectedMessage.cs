using Roguelike.Module.Weapon;

namespace Roguelike.Message {
    public struct PowerUpSelectedMessage
    {
        public WeaponController PowerUp { get; }

        public PowerUpSelectedMessage(WeaponController powerUp)
        {
            PowerUp = powerUp;
        }
    }

}
