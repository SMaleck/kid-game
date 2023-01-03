using Game.Features.EntiCS;
using Game.Static.Locators;

namespace Game.Initialization.Scenes
{
    public class LevelSceneInitializer : SceneInitializer
    {
        protected override void AwakeInternal()
        {
            FeatureLocator.Init();

            RegisterFeature<Entics>(new Entics());
        }

        protected override void StartInternal()
        {
        }
    }
}
