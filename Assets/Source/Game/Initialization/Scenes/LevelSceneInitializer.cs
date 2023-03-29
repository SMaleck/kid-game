using Game.Features.EntiCS;
using Game.Features.EntityBehaviours;
using Game.Features.GameWorld.PlayerInput;
using Game.Features.GameWorld.PlayerInput.Sources;
using Game.Features.Player;
using Game.Services.ClientInfo;
using Game.Static.Locators;

namespace Game.Initialization.Scenes
{
    public class LevelSceneInitializer : SceneInitializer
    {
        protected override void AwakeInternal()
        {
            RegisterFeature<EnticsFeature>(new EnticsFeature());
            RegisterFeature<EntityBehaviourFeature>(new EntityBehaviourFeature());

            RegisterFeature<PlayerInputFeature>(new PlayerInputFeature());
            RegisterFeature<KeyboardInputSource>(new KeyboardInputSource());
            RegisterFeature<PlayStatsFeature>(new PlayStatsFeature());

            if (ServiceLocator.Get<ClientInfoService>().IsDebug)
            {
                RegisterFeature<DebugInputSource>(new DebugInputSource());
            }
        }

        protected override void StartInternal()
        {
        }
    }
}
