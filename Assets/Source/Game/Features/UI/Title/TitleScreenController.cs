using Game.Features.Player;
using Game.Features.UI.PlayerSelect;
using Game.Features.UI.Settings;
using Game.Features.UI.Welcome;
using Game.Services.Gooey;
using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Static.Locators;
using Gooey;

namespace Game.Features.UI.Title
{
    public class TitleScreenController : ScreenController<TitleScreenView>
    {
        private SceneService _sceneService;
        private PlayerStateFeature _playerState;
        private IGuiService _guiService;

        public TitleScreenController(TitleScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            _sceneService = ServiceLocator.Get<SceneService>();
            _playerState = FeatureLocator.Get<PlayerStateFeature>();
            _guiService = ServiceLocator.Get<GuiServiceProxy>();

            View.StartButton.onClick.AddListener(OnStartClicked);
            View.SelectPlayerButton.onClick.AddListener(OnSelectPlayerClicked);
            View.SettingsButton.onClick.AddListener(OnSettingsClicked);
            View.QuitButton.onClick.AddListener(OnQuitClicked);
        }

        private void OnStartClicked()
        {
            if (_playerState.IsPlayerLoaded)
            {
                _sceneService.ToHub();
                return;
            }

            Hide();
            _guiService.TryShow<WelcomeScreenController>();
        }

        private void OnSelectPlayerClicked()
        {
            _guiService.TryShow<PlayerSelectScreenController>();
        }

        private void OnSettingsClicked()
        {
            _guiService.TryShow<SettingsModalController>();
        }

        private void OnQuitClicked()
        {
            _sceneService.Quit();
        }
    }
}
