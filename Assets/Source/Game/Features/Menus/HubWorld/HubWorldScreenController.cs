using Game.Features.LevelSelection;
using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Static.Locators;

namespace Game.Features.Menus.HubWorld
{
    public class HubWorldScreenController : ScreenController<HubWorldScreenView>
    {
        private SceneService _sceneService;
        private LevelSelectFeature _levelSelectService;

        public HubWorldScreenController(HubWorldScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            _sceneService = ServiceLocator.Get<SceneService>();
            _levelSelectService = FeatureLocator.Get<LevelSelectFeature>();

            View.StartButton.onClick.AddListener(OnOnStartClicked);
            View.ExitToTitleButton.onClick.AddListener(OnExitToTitleClicked);
        }

        private void OnOnStartClicked()
        {
            _levelSelectService.Load(LevelComplexity.C0);
        }

        private void OnExitToTitleClicked()
        {
            _sceneService.ToTitle();
        }
    }
}