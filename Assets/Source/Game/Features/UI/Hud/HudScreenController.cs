using Game.Services.Gooey.Controllers;

namespace Game.Features.UI.Hud
{
    public class HudScreenController : ScreenController<HudScreenView>
    {
        public HudScreenController(HudScreenView view)
            : base(view)
        {
        }
    }
}
