using Game.Features.Player;
using Game.Features.Savegames.Events;
using Game.Features.UI.Help;
using Game.Features.UI.Lore;
using Game.Features.UI.PlayerSelect;
using Game.Features.UI.Settings;
using Game.Features.UI.Welcome;
using Game.Services.Gooey;
using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Services.Text;
using Game.Static.Events;
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
            View.SelectPlayerButton.onClick.AddListener(GoToGui<PlayerSelectScreenController>);
            View.SettingsButton.onClick.AddListener(GoToGui<SettingsScreenController>);
            View.LoreButton.onClick.AddListener(GoToGui<LoreScreenController>);
            View.HelpButton.onClick.AddListener(GoToGui<HelpScreenController>);
            View.QuitButton.onClick.AddListener(OnQuitClicked);

            EventBus.OnEvent<PlayerSavegameLoadedEvent>(_ => PlayerSavegameLoaded());
            PlayerSavegameLoaded();
        }

        protected override void OnAfterShow()
        {
            // If there is no player loaded, we immediately forward to the welcome screen
            if (!_playerState.IsPlayerLoaded)
            {
                OpenWelcomeScreen();
            }
        }

        private void PlayerSavegameLoaded()
        {
            View.HelloText.text = _playerState.IsPlayerLoaded
                ? TextService.Get(TextKeys.HelloPlayerName, _playerState.PlayerName)
                : TextService.Get(TextKeys.Welcome);

        }

        private void OnStartClicked()
        {
            if (_playerState.IsPlayerLoaded)
            {
                _sceneService.LoadScene(SceneId.HubWorld);
                return;
            }

            OpenWelcomeScreen();
        }

        private void OpenWelcomeScreen()
        {
            Hide();
            _guiService.TryShow<WelcomeScreenController>();
        }
        
        private void GoToGui<T>() where T: IGui
        {
            _guiService.TryShow(typeof(T));
        }

        private void OnQuitClicked()
        {
            _sceneService.Quit();
        }
    }
}
