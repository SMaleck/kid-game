using Game.Features.Player;
using Game.Services.Gooey.Controllers;
using Game.Services.Scenes;
using Game.Static.Locators;

namespace Game.Features.Menus.Welcome
{
    public class WelcomeScreenController : ScreenController<WelcomeScreenView>
    {
        public WelcomeScreenController(WelcomeScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            View.StartButton.onClick.AddListener(OnStartClicked);
            View.UserNameInput.onEndEdit.AddListener(OnUsernameEdited);

            UpdateButtonState();
        }

        private void OnStartClicked()
        {
            if (!IsUsernameValid()) return;

            var username = View.UserNameInput.text;
            FeatureLocator.Get<PlayerStateFeature>().Create(username);

            Hide();

            ServiceLocator.Get<SceneService>().To(SceneId.Level);
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
