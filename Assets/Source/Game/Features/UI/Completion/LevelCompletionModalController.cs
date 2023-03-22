using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Static.Locators;

namespace Game.Features.UI.Completion
{
    public class LevelCompletionModalController : ModalController<LevelCompletionModalView>
    {
        public LevelCompletionModalController(LevelCompletionModalView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            View.BackButton.onClick
                .AddListener(OnBackClicked);

            View.ReplayButton.onClick
                .AddListener(OnReplayClicked);
        }

        protected void OnBackClicked()
        {
            ServiceLocator.Get<SceneService>().ToHub();
        }

        protected void OnReplayClicked()
        {
            ServiceLocator.Get<SceneService>().ReloadLevel();
        }
    }
}
