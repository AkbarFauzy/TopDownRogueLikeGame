using Agate.MVC.Base;

namespace Roguelike.Module.ConfigData
{
    public interface IConfigDataModel : IBaseModel
    {
        public bool IsBgmOn { get; }
        public bool IsSfxOn { get; }
    }
}

