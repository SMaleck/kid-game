using Game.Services.Gooey.Controllers;

namespace Game.Features.Menus.Welcome
{
    public class WelcomeScreenController : Controller<WelcomeScreenView>
    {
        public WelcomeScreenController(WelcomeScreenView view)
            : base(view)
        {
        }
    }
}
