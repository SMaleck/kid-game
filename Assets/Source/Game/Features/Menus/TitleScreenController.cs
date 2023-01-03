using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Static.Locators;

namespace Game.Features.Menus
{
    public class TitleScreenController : ScreenController<TitleScreenView>
    {
        public TitleScreenController(TitleScreenView view)
            : base(view)
        {
            SetupView();
        }

        private void SetupView()
        {
            View.StartButton.onClick.AddListener(() =>
            {
                ServiceLocator.Get<SceneService>().To(SceneId.Level);
            });
        }
    }
}
