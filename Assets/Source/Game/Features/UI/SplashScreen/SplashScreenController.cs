using Game.Features.UI.Title;
using Game.Services.Gooey;
using Game.Services.Gooey.Controllers;
using Game.Static.Locators;

namespace Game.Features.UI.SplashScreen
{
    public class SplashScreenController : ScreenController<SplashScreenView>
    {
        public SplashScreenController(SplashScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            View.ContinueButton.onClick.AddListener(() => Hide(GoToTitleScreen));
        }

        private void GoToTitleScreen()
        {
            ServiceLocator.Get<GuiServiceProxy>().TryShow<TitleScreenController>();
        }
    }
}
