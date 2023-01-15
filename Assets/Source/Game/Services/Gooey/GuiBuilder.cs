using Game.Services.Gooey.Controllers;
using Game.Services.Gooey.Data;
using Game.Services.Gooey.Views;
using Game.Static.Locators;
using Gooey;

namespace Game.Services.Gooey
{
    public class GuiBuilder : IService
    {
        public IGui Build(View view)
        {
            var gui = ControllerFactory.Create(view);
            ServiceLocator.Get<GuiServiceProxy>().Add(gui);

            gui.SetIsVisible(view.StartsVisible);

            return gui;
        }

        public IGui Build<TView>()
        {
            var viewPrefab = DataLocator.Get<GuiPrefabDataSource>()
                .GetPrefab(typeof(TView));

            return Build(viewPrefab);
        }
    }
}
