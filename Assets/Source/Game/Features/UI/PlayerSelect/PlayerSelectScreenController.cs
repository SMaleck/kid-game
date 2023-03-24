using Game.Features.Savegames;
using Game.Features.UI.Welcome;
using Game.Services.Gooey;
using Game.Services.Gooey.Controllers;
using Game.Static.Locators;
using Gooey;

namespace Game.Features.UI.PlayerSelect
{
    public class PlayerSelectScreenController : ScreenController<PlayerSelectScreenView>
    {
        private IGuiService _guiService;

        public PlayerSelectScreenController(PlayerSelectScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            _guiService = ServiceLocator.Get<GuiServiceProxy>();

            View.BackButton.onClick.AddListener(() => Hide());
            View.CreateButton.onClick.AddListener(OnCreateClicked);

            var playerMetaSavegames = FeatureLocator.Get<SavegameFeature>().GlobalStorage.Savegame.PlayerSavegames;
            foreach (var savegame in playerMetaSavegames)
            {
                View.Add(savegame);
            }
        }

        private void OnCreateClicked()
        {
            Hide(() => _guiService.TryShow<WelcomeScreenController>());
        }
    }
}
