// This file is GENERATED! Changes might get lost.
using System;
using Game.Services.Gooey.Views;
using Gooey;
using Game.Features.UI.Welcome;
using Game.Features.UI.Title;
using Game.Features.UI.Settings;
using Game.Features.UI.PlayerSelect;
using Game.Features.UI.Pause;
using Game.Features.UI.Loading;
using Game.Features.UI.Hud;
using Game.Features.UI.HubWorld;
using Game.Features.UI.Completion;


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

                case "SettingsModalView":
                    return new SettingsModalController((SettingsModalView)view);

                case "PlayerSelectScreenView":
                    return new PlayerSelectScreenController((PlayerSelectScreenView)view);

                case "PauseModalView":
                    return new PauseModalController((PauseModalView)view);

                case "LoadingScreenView":
                    return new LoadingScreenController((LoadingScreenView)view);

                case "HudScreenView":
                    return new HudScreenController((HudScreenView)view);

                case "HubWorldScreenView":
                    return new HubWorldScreenController((HubWorldScreenView)view);

                case "LevelCompletionModalView":
                    return new LevelCompletionModalController((LevelCompletionModalView)view);


                default:
                    throw new InvalidOperationException($"No controller found for View [{viewName}]");
            }
        }
    }
}
