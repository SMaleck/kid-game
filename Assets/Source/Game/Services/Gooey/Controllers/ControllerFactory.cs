// This file is GENERATED! Changes might get lost.
using System;
using Game.Services.Gooey.Views;
using Gooey;
using Game.Features.Menus;


namespace Game.Services.Gooey.Controllers
{
    public static class ControllerFactory
    {
        public static IGui Create(View view)
        {
            var viewName = view.GetType().Name;
            switch (viewName)
            {
                case "TitleScreenView":
                    return new TitleScreenController((TitleScreenView)view);


                default:
                    throw new InvalidOperationException($"No controller found for View [{viewName}]");
            }
        }
    }
}
