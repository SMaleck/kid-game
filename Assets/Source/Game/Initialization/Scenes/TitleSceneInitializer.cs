using Game.Features.UI.SplashScreen;
using Game.Features.UI.Title;
using Game.Services.Gooey;
using Game.Static.Locators;

namespace Game.Initialization.Scenes
{
    public class TitleSceneInitializer : SceneInitializer
    {
        // HACK Quick and easy solution to show the splashscreen only once
        private static bool _wasSplashScreenShown = false;

        protected override void AwakeInternal()
        {
        }

        protected override void StartInternal()
        {
            if (_wasSplashScreenShown)
            {
                ServiceLocator.Get<GuiServiceProxy>().TryShow<TitleScreenController>();
            }
            else
            {
                _wasSplashScreenShown = true;
                ServiceLocator.Get<GuiServiceProxy>().TryShow<SplashScreenController>();
            }
        }
    }
}
