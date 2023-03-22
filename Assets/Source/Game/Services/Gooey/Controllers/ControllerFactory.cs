// This file is GENERATED! Changes might get lost.
using System;
using Game.Features.UI.Completion;
using Game.Features.UI.HubWorld;
using Game.Features.UI.Hud;
using Game.Features.UI.Pause;
using Game.Features.UI.Title;
using Game.Features.UI.Welcome;
using Game.Services.Gooey.Views;
using Gooey;


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
