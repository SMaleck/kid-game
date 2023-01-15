using Game.Services.Scenes;
using Game.Services.Scenes.Events;
using Game.Static.Events;
using Game.Static.Locators;

namespace Game.Features.Savegames
{
    public class SavegameAutoSaveFeature : Feature
    {
        private SavegameFeature _savegameFeature;

        public override void Start()
        {
            _savegameFeature = FeatureLocator.Get<SavegameFeature>();

            EventBus.OnEvent<BeforeQuitEvent>(AutoSave);
            EventBus.OnEvent<BeforeSceneUnloadEvent>(AutoSave);
        }

        private void AutoSave(object eventArgs)
        {
            _savegameFeature.SaveAll();
        }
    }
}
