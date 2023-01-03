using Game.Services.Gooey.Views;
using Gooey.Layers;

namespace Game.Services.Gooey.Controllers
{
    public class WindowController<TView> : Controller<TView>, IWindow where TView : View
    {
        public WindowController(TView view) : base(view)
        {
        }
    }
}
