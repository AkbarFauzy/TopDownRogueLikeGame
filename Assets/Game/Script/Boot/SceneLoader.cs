using Agate.MVC.Base;
using Roguelike.Utility;


namespace Roguelike.Boot {
    public class SceneLoader : BaseLoader<SceneLoader>
    {
        protected override string SplashScene => GameScene.SplashScreen;
    }

}

