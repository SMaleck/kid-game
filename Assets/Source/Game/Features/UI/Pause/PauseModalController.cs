using Game.Features.Ticking;
using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Static.Locators;

namespace Game.Features.UI.Pause
{
    public class PauseModalController : ScreenController<PauseModalView>
    {
        private SceneService _sceneService;
        private TickerFeature _tickerFeature;

        public PauseModalController(PauseModalView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            _sceneService = ServiceLocator.Get<SceneService>();
            _tickerFeature = FeatureLocator.Get<TickerFeature>();

            View.ResumeButton.onClick.AddListener(OnResumeClicked);
            View.RestartButton.onClick.AddListener(OnRestartClicked);
            View.QuitButton.onClick.AddListener(OnQuitClicked);
        }

        private void OnResumeClicked()
        {
            Hide();
            _tickerFeature.SceneTicker.SetIsPaused(false);
        }

        private void OnRestartClicked()
        {
            _sceneService.ReloadLevel();
        }

        private void OnQuitClicked()
        {
            _sceneService.ToHub();
        }
    }
}