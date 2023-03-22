using Game.Features.Player;
using Game.Features.UI.Welcome;
using Game.Services.Gooey;
using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Static.Locators;

namespace Game.Features.UI.Title
{
    public class TitleScreenController : ScreenController<TitleScreenView>
    {
        private SceneService _sceneService;
        private PlayerStateFeature _playerState;

        public TitleScreenController(TitleScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            _sceneService = ServiceLocator.Get<SceneService>();
            _playerState = FeatureLocator.Get<PlayerStateFeature>();

            View.StartButton.onClick.AddListener(OnStartClicked);
            View.SelectPlayerButton.onClick.AddListener(OnSelectPlayerClicked);
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
            ServiceLocator.Get<GuiServiceProxy>().TryShow<WelcomeScreenController>();
        }

        private void OnSelectPlayerClicked()
        {
        }

        private void OnQuitClicked()
        {
            _sceneService.Quit();
        }
    }
}
