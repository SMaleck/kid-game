using Game.Services.Gooey.Controllers;

namespace Game.Features.UI.PlayerSelect
{
    public class PlayerSelectScreenController : ScreenController<PlayerSelectScreenView>
    {
        public PlayerSelectScreenController(PlayerSelectScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
        }
    }
}
