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

            foreach (var levelItem in View.LevelItems)
            {
                levelItem.StartButton.onClick.AddListener(() => OnOnStartClicked(levelItem.Complexity));
            }
            
            View.ExitToTitleButton.onClick.AddListener(OnExitToTitleClicked);
        }

        private void OnOnStartClicked(LevelComplexity complexity)
        {
            _levelSelectService.Load(complexity);
        }

        private void OnExitToTitleClicked()
        {
            _sceneService.ToTitle();
        }
    }
}