using Agate.MVC.Base;

namespace Roguelike.Module.HUD 
{
    public interface IHUDModel : IBaseModel
    {
        public int Level { get; }
        public float Time { get; }
    }

}

