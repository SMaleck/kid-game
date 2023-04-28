using Game.Initialization.ScriptableObjects;
using Game.Services.ClientInfo;
using Game.Services.Scenes;
using Game.Static.Locators;
using UnityEngine;

namespace Game.Initialization.Scenes
{
    public class RootSceneInitializer : SceneInitializer
    {
        [SerializeField] private DataInitializer _dataInitializer;

        protected override void AwakeInternal()
        {
            _dataInitializer.Initialize();

            ServiceInitializer.Initialize();
            GameInitializer.Initialize();

            AppSetup();
        }

        protected override void StartInternal()
        {
            GameInitializer.Start();
            ServiceLocator.Get<SceneService>().InitialLoad();
        }

        private void AppSetup()
        {
            var clientInfoService = ServiceLocator.Get<ClientInfoService>();
            if (clientInfoService.PlatformType == PlatformType.Mobile)
            {
                Screen.sleepTimeout = SleepTimeout.NeverSleep;
            }
        }
    }
}