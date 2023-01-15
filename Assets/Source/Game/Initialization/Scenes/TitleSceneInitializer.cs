using Game.Features.Player;
using Game.Features.Savegames;

namespace Game.Initialization.Scenes
{
    public class TitleSceneInitializer : SceneInitializer
    {
        protected override void AwakeInternal()
        {
            RegisterFeature<SavegameFeature>(new SavegameFeature());
            RegisterFeature<SavegameAutoSaveFeature>(new SavegameAutoSaveFeature());
            RegisterFeature<PlayerStateFeature>(new PlayerStateFeature());
        }

        protected override void StartInternal()
        {
        }
    }
}
