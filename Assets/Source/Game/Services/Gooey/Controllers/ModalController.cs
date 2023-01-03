using Game.Services.Gooey.Views;
using Gooey.Layers;

namespace Game.Services.Gooey.Controllers
{
    public class ModalController<TView> : Controller<TView>, IModal where TView : View
    {
        public ModalController(TView view) : base(view)
        {
        }
    }
}
