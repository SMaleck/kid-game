using Game.Services.ClientInfo;
using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Services.Text;
using Game.Static.Locators;
using Game.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.Features.UI.Settings
{
    public class SettingsScreenController : ScreenController<SettingsScreenView>
    {
        private SceneService _sceneService;

        public SettingsScreenController(SettingsScreenView view)
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

            var infoString = ServiceLocator.Get<ClientInfoService>().InfoString;
            View.ClientInfoText.text = $"Client Info: {infoString}";

            View.GitHubUrlText.OnClick += (eventData) => OnUrlClick(eventData, View.GitHubUrlText.Text);
        }

        private void SetLanguage(Language language)
        {
            TextService.SetLanguage(language);
            _sceneService.ReloadGame();
        }

        // There is only 1 link in all the loca atm.
        // So we only check if the link was actually clicked, without using the ID behind it
        private void OnUrlClick(PointerEventData eventData, TMP_Text viewUrlText)
        {
            var linkIndex = TMP_TextUtilities.FindIntersectingLink(viewUrlText, Input.mousePosition, null);
            if (linkIndex != -1)
            {
                Application.OpenURL(ProjectConst.GitHubURL);
            }
        }
    }
}