using Game.Features.Player;
using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Static.Locators;

namespace Game.Features.Menus.HubWorld
{
    public class HubWorldScreenController : ScreenController<HubWorldScreenView>
    {
        private SceneService _sceneService;
        private PlayerStateFeature _playerState;

        public HubWorldScreenController(HubWorldScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            _sceneService = ServiceLocator.Get<SceneService>();
            _playerState = FeatureLocator.Get<PlayerStateFeature>();

            View.StartButton.onClick.AddListener(OnOnStartClicked);
            View.ExitToTitleButton.onClick.AddListener(OnExitToTitleClicked);
        }

        private void OnOnStartClicked()
        {
            _sceneService.To(SceneId.Level);
        }

        private void OnExitToTitleClicked()
        {
            _sceneService.To(SceneId.Title);
        }
    }
}