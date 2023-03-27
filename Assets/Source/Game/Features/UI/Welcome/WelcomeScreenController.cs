using Game.Features.Player;
using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Static.Locators;
using Unity.VisualScripting.IonicZip;

namespace Game.Features.UI.Welcome
{
    public class WelcomeScreenController : ScreenController<WelcomeScreenView>
    {
        public WelcomeScreenController(WelcomeScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            var canGoBack = FeatureLocator.Get<PlayerStateFeature>().IsPlayerLoaded;
            View.BackButtonParent.SetActive(canGoBack);

            View.StartButton.onClick.AddListener(OnStartClicked);
            View.BackButton.onClick.AddListener(OnBackClicked);
            View.UserNameInput.onEndEdit.AddListener(OnUsernameEdited);

            UpdateButtonState();
        }
        
        private void OnStartClicked()
        {
            if (!IsUsernameValid()) return;

            var username = View.UserNameInput.text;
            FeatureLocator.Get<PlayerStateFeature>().Create(username);

            Hide();

            ServiceLocator.Get<SceneService>().ToHub();
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
            var username = View.UserNameInput.text;
            return !string.IsNullOrWhiteSpace(username);
        }
    }
}
