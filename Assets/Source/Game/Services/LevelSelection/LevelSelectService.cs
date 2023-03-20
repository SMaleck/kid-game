using Game.Services.Scenes;
using Game.Static.Locators;

namespace Game.Services.LevelSelection
{
    public class LevelSelectService : Service
    {
        public LevelComplexity Complexity { get; private set; } = LevelComplexity.C0;

        public void Load(LevelComplexity complexity)
        {
            Complexity = complexity;
            ServiceLocator.Get<SceneService>().ToLevel();
        }
    }
}
