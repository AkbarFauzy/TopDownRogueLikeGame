
namespace Roguelike.Message 
{
    public struct PlayerLevelUpMessage
    {
        public int Level { get; private set; }
        public PlayerLevelUpMessage(int level) {
            Level = level;
        }

    }
}
