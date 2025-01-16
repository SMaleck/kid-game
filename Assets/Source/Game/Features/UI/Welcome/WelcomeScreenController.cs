using Game.Features.Player;
using Game.Services.ClientInfo;
using Game.Services.Gooey.Controllers;
using Game.Services.Gooey.Views;
using Game.Services.Scenes;
using Game.Static.Locators;

namespace Game.Features.UI.Welcome
{
    public class WelcomeScreenController : ScreenController<WelcomeScreenView>
    {
        private readonly ClientInfoService _clientInfo;

        public WelcomeScreenController(WelcomeScreenView view)
            : base(view)
        {
            _clientInfo = ServiceLocator.Get<ClientInfoService>();
        }

        protected override void Initialize()
        {
            var canGoBack = FeatureLocator.Get<PlayerStateFeature>().IsPlayerLoaded;
            View.BackButtonParent.SetActive(canGoBack);

            View.StartButton.onClick.AddListener(OnStartClicked);
            View.BackButton.onClick.AddListener(OnBackClicked);

            SetupInput();
            UpdateButtonState();
        }

        private void SetupInput()
        {
            if (_clientInfo.PlatformType == PlatformType.Browser)
            {
                View.UserNameInputLegacy.onValueChanged.AddListener(OnUsernameEdited);
                View.UserNameInputLegacy.onEndEdit.AddListener(OnUsernameEdited);
            }
            else
            {
                View.UserNameInput.onValueChanged.AddListener(OnUsernameEdited);
                View.UserNameInput.onEndEdit.AddListener(OnUsernameEdited);
            }
        }

        private string GetUsername()
        {
            return _clientInfo.PlatformType == PlatformType.Browser
                ? View.UserNameInputLegacy.text
                : View.UserNameInput.text;
        }

        private void OnStartClicked()
        {
            if (!IsUsernameValid()) return;

            var username = GetUsername();
            FeatureLocator.Get<PlayerStateFeature>().Create(username);

            Hide();

            ServiceLocator.Get<SceneService>().LoadScene(SceneId.HubWorld);
        }

        private void OnBackClicked()
        {
            Hide();
        }

        private void OnUsernameEdited(string eventArgs)
        {
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            View.StartButton.interactable = IsUsernameValid();
        }

        private bool IsUsernameValid()
        {
            var username = GetUsername();
            return !string.IsNullOrWhiteSpace(username);
        }
    }
}
