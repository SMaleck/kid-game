using Game.Services.Scenes;
using Game.Static.Locators;

namespace Game.Features.LevelSelection
{
    public class LevelSelectFeature : Feature
    {
        public LevelComplexity Complexity { get; private set; } = LevelComplexity.C0;

        public void Load(LevelComplexity complexity)
        {
            Complexity = complexity;
            ServiceLocator.Get<SceneService>().ToLevel();
        }
    }
}
