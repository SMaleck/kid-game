using Game.Features.Savegames;

namespace Game.Initialization.Scenes
{
    public class TitleSceneInitializer : SceneInitializer
    {
        protected override void AwakeInternal()
        {
            RegisterFeature<SavegameFeature>(new SavegameFeature());
        }

        protected override void StartInternal()
        {
        }
    }
}
