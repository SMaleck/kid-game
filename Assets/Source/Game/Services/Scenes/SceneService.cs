using Game.Features.UI.Loading;
using Game.Services.Gooey;
using Game.Services.Scenes.Events;
using Game.Static.Events;
using Game.Static.Locators;
using Game.Utility;
using Gooey;
using System;

namespace Game.Services.Scenes
{
    public class SceneService : Service
    {
        private readonly IGuiService _guiService;

        public SceneId CurrentSceneId => SceneManagerProxy.CurrentSceneId;

        public SceneService()
        {
            SceneManagerProxy.Init();
            _guiService = ServiceLocator.Get<GuiServiceProxy>();
        }

        public void InitialLoad()
        {
            if (SceneManagerProxy.SceneCount > 1 ||
                CurrentSceneId != SceneId.Root)
            {
                Error($"Initial Load can only be performed when game is still in the root scene. Scene: {CurrentSceneId}");
                return;
            }

            SceneManagerProxy.LoadAndSwitchScene(SceneId.Title, false, HideLoadingScreen);
        }

        public void ReloadGame()
        {
            if (CurrentSceneId == SceneId.Root)
            {
                InitialLoad();
                return;
            }
            if (CurrentSceneId == SceneId.Title)
            {
                ShowLoadingScreen(() =>
                {
                    SceneManagerProxy.ReloadCurrent(HideLoadingScreen);
                });
                return;
            }

            ToTitle();
        }

        public void ToTitle()
        {
            LoadAndSwitch(SceneId.Title, true);
        }

        public void ToHub()
        {
            LoadAndSwitch(SceneId.HubWorld, true);
        }

        public void ToLevel(SceneId levelId)
        {
            if (levelId.IsLevelScene())
            {
                LoadAndSwitch(levelId, true);
            }
        }

        public void ReloadLevel()
        {
            if (!CurrentSceneId.IsLevelScene())
            {
                Error($"Current scene is not a level. Current: [{CurrentSceneId}]");
                return;
            }

            ShowLoadingScreen(() =>
            {
                SceneManagerProxy.ReloadCurrent(HideLoadingScreen);
            });
        }

        public void Quit()
        {
            EventBus.Publish(new BeforeQuitEvent());
            UnityEngine.Application.Quit();
        }

        private void LoadAndSwitch(SceneId scene, bool unloadCurrent)
        {
            ShowLoadingScreen(() =>
            {
                SceneManagerProxy.LoadAndSwitchScene(scene, unloadCurrent, HideLoadingScreen);
            });
        }

        private void ShowLoadingScreen(Action next)
        {
            _guiService.TryShow<LoadingScreenController>(next);
        }

        private void HideLoadingScreen()
        {
            _guiService.TryHide<LoadingScreenController>();
        }

        private void Log(string message)
        {
            GameLog.Log($"[{nameof(SceneService)}] {message}");
        }

        private void Error(string message)
        {
            GameLog.Error($"[{nameof(SceneService)}] {message}");
        }
    }
}
