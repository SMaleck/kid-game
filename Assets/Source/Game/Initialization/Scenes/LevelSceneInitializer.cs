using Game.Features.EntiCS;
using Game.Features.EntityBehaviours;

namespace Game.Initialization.Scenes
{
    public class LevelSceneInitializer : SceneInitializer
    {
        protected override void AwakeInternal()
        {
            RegisterFeature<EnticsFeature>(new EnticsFeature());
            RegisterFeature<EntityBehaviourFeature>(new EntityBehaviourFeature());
        }

        protected override void StartInternal()
        {
        }
    }
}
