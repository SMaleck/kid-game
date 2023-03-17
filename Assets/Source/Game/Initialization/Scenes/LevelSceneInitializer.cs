using Game.Features.EntiCS;
using Game.Features.EntityBehaviours;
using Game.Features.GameWorld.PlayerInput;

namespace Game.Initialization.Scenes
{
    public class LevelSceneInitializer : SceneInitializer
    {
        protected override void AwakeInternal()
        {
            RegisterFeature<EnticsFeature>(new EnticsFeature());
            RegisterFeature<EntityBehaviourFeature>(new EntityBehaviourFeature());
            RegisterFeature<PlayerInputFeature>(new PlayerInputFeature());
        }

        protected override void StartInternal()
        {
        }
    }
}
