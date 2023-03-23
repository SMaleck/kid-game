using Game.Services.Gooey.Controllers;

namespace Game.Features.UI.Loading
{
    public class LoadingScreenController : ScreenController<LoadingScreenView>
    {
        public LoadingScreenController(LoadingScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
        }
    }
}
