// This file is GENERATED! Changes might get lost.
using System;
using Game.Services.Gooey.Views;
using Gooey;
using Game.Features.Menus;
using Game.Features.Menus.Welcome;


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

                case "WelcomeScreenView":
                    return new WelcomeScreenController((WelcomeScreenView)view);


                default:
                    throw new InvalidOperationException($"No controller found for View [{viewName}]");
            }
        }
    }
}
