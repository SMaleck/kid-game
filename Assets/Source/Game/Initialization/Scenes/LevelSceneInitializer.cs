using Game.Features.EntiCS;

namespace Game.Initialization.Scenes
{
    public class LevelSceneInitializer : SceneInitializer
    {
        protected override void AwakeInternal()
        {
            RegisterFeature<EnticsFeature>(new EnticsFeature());
        }

        protected override void StartInternal()
        {
        }
    }
}
