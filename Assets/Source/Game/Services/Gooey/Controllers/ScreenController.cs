using Game.Services.Gooey.Views;
using Gooey.Layers;

namespace Game.Services.Gooey.Controllers
{
    public class ScreenController<TView> : Controller<TView>, IScreen where TView : View
    {
        public ScreenController(TView view) : base(view)
        {
        }
    }
}
