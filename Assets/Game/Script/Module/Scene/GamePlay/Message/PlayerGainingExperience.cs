
namespace Roguelike.Message {
    public struct PlayerGainingExperience
    {
        public int Exp { get; private set; }
        public int MaxExp { get; private set; }

        public PlayerGainingExperience(int exp, int maxExp) {
            Exp = exp;
            MaxExp = maxExp;
        }

    }
}
