namespace Roguelike.Message
{
    public struct UpdateSfxConfigMessage
    {
        public bool IsSfxOn { get; private set; }
        public UpdateSfxConfigMessage(bool isSfxOn)
        {
            IsSfxOn = isSfxOn;
        }
    }
}


