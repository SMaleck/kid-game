using Game.Features.EntiCS;

namespace Game.Initialization.Scenes
{
    public class LevelSceneInitializer : SceneInitializer
    {
        protected override void AwakeInternal()
        {
            RegisterFeature<Entics>(new Entics());
        }

        protected override void StartInternal()
        {
        }
    }
}
