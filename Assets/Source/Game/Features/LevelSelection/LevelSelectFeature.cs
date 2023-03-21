using Game.Services.Scenes;
using Game.Static.Locators;
using System;

namespace Game.Features.LevelSelection
{
    public class LevelSelectFeature : Feature
    {
        public LevelComplexity Complexity { get; private set; } = LevelComplexity.C0;

        public void Load(LevelComplexity complexity)
        {
            Complexity = complexity;

            var levelId = ComplexityToLevelId(Complexity);
            ServiceLocator.Get<SceneService>().ToLevel(levelId);
        }

        private SceneId ComplexityToLevelId(LevelComplexity complexity)
        {
            switch (complexity)
            {
                case LevelComplexity.C0:
                    return SceneId.Level_C0;

                case LevelComplexity.C1:
                    return SceneId.Level_C1;

                case LevelComplexity.C2:
                    return SceneId.Level_C2;

                default:
                    throw new ArgumentOutOfRangeException(nameof(complexity), complexity, null);
            }
        }
    }
}
