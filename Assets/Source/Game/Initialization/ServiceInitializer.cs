using Game.Services.Application;
using Game.Services.Gooey;
using Game.Services.Scenes;
using Game.Static.Locators;
using Game.Utility;

namespace Game.Initialization
{
    public static class ServiceInitializer
    {
        public static bool IsInitialized { get; private set; }

        public static void Initialize()
        {
            if (IsInitialized)
            {
                GameLog.Warn($"{nameof(ServiceInitializer)} already initialized");
                return;
            }

            InitializeInternal();
            IsInitialized = true;
        }

        private static void InitializeInternal()
        {
            ServiceLocator.Register<ApplicationStateService>(new ApplicationStateService());
            ServiceLocator.Register<SceneService>(new SceneService());
            ServiceLocator.Register<GuiBuilder>(new GuiBuilder());
            ServiceLocator.Register<GuiServiceProxy>(new GuiServiceProxy());
        }
    }
}
