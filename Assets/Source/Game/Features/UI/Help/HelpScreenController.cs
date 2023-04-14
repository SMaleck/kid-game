using Game.Services.Gooey.Controllers;

namespace Game.Features.UI.Help
{
    public class HelpScreenController : ScreenController<HelpScreenView>
    {
        public HelpScreenController(HelpScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            View.BackButton.onClick.AddListener(() => Hide());
        }
    }
}
