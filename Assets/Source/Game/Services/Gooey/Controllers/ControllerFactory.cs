// This file is GENERATED! Changes might get lost.
using System;
using Game.Services.Gooey.Views;
using Gooey;
using Game.Features.Menus.Welcome;
using Game.Features.Menus.Title;
using Game.Features.Menus.Pause;
using Game.Features.Menus.HubWorld;
using Game.Features.GameWorld.Levels.Completion;
using Game.Features.GameWorld.Hud;


namespace Game.Services.Gooey.Controllers
{
    public static class ControllerFactory
    {
        public static IGui Create(View view)
        {
            var viewName = view.GetType().Name;
            switch (viewName)
            {
                case "WelcomeScreenView":
                    return new WelcomeScreenController((WelcomeScreenView)view);

                case "TitleScreenView":
                    return new TitleScreenController((TitleScreenView)view);

                case "PauseScreenView":
                    return new PauseScreenController((PauseScreenView)view);

                case "HubWorldScreenView":
                    return new HubWorldScreenController((HubWorldScreenView)view);

                case "LevelCompletionModalView":
                    return new LevelCompletionModalController((LevelCompletionModalView)view);

                case "HudScreenView":
                    return new HudScreenController((HudScreenView)view);


                default:
                    throw new InvalidOperationException($"No controller found for View [{viewName}]");
            }
        }
    }
}
