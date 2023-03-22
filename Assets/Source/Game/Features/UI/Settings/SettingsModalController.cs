using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Services.Text;
using Game.Static.Locators;

namespace Game.Features.UI.Settings
{
    public class SettingsModalController : ModalController<SettingsModalView>
    {
        private SceneService _sceneService;

        public SettingsModalController(SettingsModalView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            _sceneService = ServiceLocator.Get<SceneService>();

            View.CloseButton.onClick.AddListener(() => Hide());
            View.ENLangButton.onClick.AddListener(() => SetLanguage(Language.English));
            View.DELangButton.onClick.AddListener(() => SetLanguage(Language.German));
            View.PLLangButton.onClick.AddListener(() => SetLanguage(Language.Polish));
        }

        private void SetLanguage(Language language)
        {
            TextService.SetLanguage(language);
            _sceneService.ReloadGame();
        }
    }
}