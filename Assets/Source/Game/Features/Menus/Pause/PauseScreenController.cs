using Game.Features.Ticking;
using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Static.Locators;

namespace Game.Features.Menus.Pause
{
    public class PauseScreenController : ScreenController<PauseScreenView>
    {
        private SceneService _sceneService;
        private TickerFeature _tickerFeature;

        public PauseScreenController(PauseScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            _sceneService = ServiceLocator.Get<SceneService>();
            _tickerFeature = FeatureLocator.Get<TickerFeature>();

            View.ResumeButton.onClick.AddListener(OnResumeClicked);
            View.RestartButton.onClick.AddListener(OnRestartClicked);
            View.QuitButton.onClick.AddListener(OnExitToTitleClicked);
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

        private void OnExitToTitleClicked()
        {
            _sceneService.ToTitle();
        }
    }
}