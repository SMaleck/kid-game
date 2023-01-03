using Game.Features.Menus;
using Game.Services.Gooey;
using Game.Static.Locators;

namespace Game.Initialization.Scenes
{
    public class TitleSceneInitializer : SceneInitializer
    {
        protected override void AwakeInternal()
        {
            //ServiceLocator.Get<GuiBuilder>().Build<TitleScreenView>();
        }

        protected override void StartInternal()
        {
        }
    }
}
