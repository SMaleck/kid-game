using Game.Services.Gooey.Controllers;

namespace Game.Features.UI.Lore
{
    public class LoreScreenController : ScreenController<LoreScreenView>
    {
        public LoreScreenController(LoreScreenView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            View.BackButton.onClick.AddListener(() => Hide());
        }
    }
}
