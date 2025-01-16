using Game.Features.Ticking;
using Game.Features.UI.Loading;
using Game.Services.Gooey;
using Game.Services.Scenes.Events;
using Game.Static.Events;
using Game.Static.Locators;
using Game.Utility;
using Gooey;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

namespace Game.Services.Scenes
{
    public class SceneService : Service
    {
        private readonly IGuiService _guiService;
        private bool _isLoading;

        public SceneService()
        {
            _guiService = ServiceLocator.Get<GuiServiceProxy>();
        }

        public void LoadScene(SceneId sceneId)
        {
            if (_isLoading) throw new InvalidOperationException("Scene Load is already in progress.");
            _isLoading = true;

            ShowLoadingScreenAsync(() =>
            {
                UnloadAllScenes(() =>
                {
                    LoadSceneAsync(sceneId, () =>
                    {
                        _isLoading = false;
                        HideLoadingScreen();
                    });
                });
            });
        }

        public void LoadLevel(SceneId sceneId)
        {
            if (_isLoading) throw new InvalidOperationException("Scene Load is already in progress.");
            if (!sceneId.IsLevelScene()) throw new InvalidOperationException($"{sceneId} is not a level scene.");
            _isLoading = true;
            
            ShowLoadingScreenAsync(() =>
            {
                // Unloading all loaded Level Scenes...
                UnloadAllScenes(() =>
                {
                    // ...then we can load the actual level
                    LoadSceneAsync(SceneId.Level_Root, () =>
                    {
                        LoadSceneAsync(sceneId, () =>
                        {
                            EventBus.Publish(new AllLevelScenesLoadedEvent());

                            _isLoading = false;
                            HideLoadingScreen();
                        });
                    });
                });
            });
        }

        public void ReloadLevel()
        {
            var sceneIds = GetLoadedScenesSafe()
                .Select(e => e.name.ToSceneId())
                .Where(e => e.IsLevelScene())
                .ToList();

            if (sceneIds.Count == 0)
            {
                Error("No level scenes loaded. Ignoring reload attempt.");
                return;
            }

            var levelSceneId = sceneIds.First(e => e != SceneId.Level_Root);
            LoadLevel(levelSceneId);
        }

        public void ReloadGame()
        {
            LoadScene(SceneId.Title);
        }

        public void Quit()
        {
            EventBus.Publish(new BeforeQuitEvent());
            UnityEngine.Application.Quit();
        }

        private void UnloadAllScenes(Action onComplete)
        {
            var sceneIds = GetLoadedScenesSafe()
                .Select(e => e.name.ToSceneId())
                .ToList();

            UnloadScenes(sceneIds, 0, onComplete);
        }

        private void UnloadLevelScenes(Action onComplete)
        {
            var sceneIds = GetLoadedScenesSafe()
                .Select(e => e.name.ToSceneId())
                .Where(e => e.IsLevelScene())
                .ToList();

            UnloadScenes(sceneIds, 0, onComplete);
        }

        private void UnloadScenes(List<SceneId> sceneIds, int index, Action onComplete)
        {
            if (index >= sceneIds.Count)
            {
                onComplete.Invoke();
                return;
            }

            UnloadSceneAsync(sceneIds[index], () =>
            {
                index++;
                UnloadScenes(sceneIds, index, onComplete);
            });
        }

        #region Loading Screen

        private void ShowLoadingScreenAsync(Action onComplete)
        {
            _guiService.TryShow<LoadingScreenController>(onComplete);
        }

        private void HideLoadingScreen()
        {
            _guiService.TryHide<LoadingScreenController>();
        }

        #endregion

        #region Unity

        private static int SceneCount => SceneManager.sceneCount;

        private static Scene[] GetLoadedScenes()
        {
            var scenes = new Scene[SceneCount];
            for (var i = 0; i < SceneCount; i++)
            {
                scenes[i] = SceneManager.GetSceneAt(i);
            }

            return scenes;
        }

        private static Scene[] GetLoadedScenesSafe()
        {
            var scenes = new Scene[SceneCount];
            for (var i = 0; i < SceneCount; i++)
            {
                scenes[i] = SceneManager.GetSceneAt(i);
            }

            return scenes
                .Where(e => e.name.ToSceneId() != SceneId.Root)
                .ToArray();
        }

        private static bool IsSceneIdLoaded(SceneId scene)
        {
            return GetLoadedScenes()
                .Any(e => e.name.ToSceneId() == scene);
        }

        private static SceneId GetActiveSceneId()
        {
            return SceneManager.GetActiveScene().name.ToSceneId();
        }

        private void LoadSceneAsync(SceneId sceneId, Action onComplete)
        {
            Log($"Loading Scene: [{sceneId}]");

            FeatureLocator.Get<TickerFeature>().OnNextFrame(() =>
            {
                var sceneLoad = SceneManager.LoadSceneAsync((int)sceneId, LoadSceneMode.Additive);
                sceneLoad.completed += _ =>
                {
                    var toScene = SceneManager.GetSceneByName(sceneId.ToSceneName());
                    SceneManager.SetActiveScene(toScene);
                    EventBus.Publish(new StartSceneEvent(sceneId));

                    onComplete.Invoke();
                };
            });
        }

        private void UnloadSceneAsync(SceneId sceneId, Action onComplete)
        {
            Log($"Unloading Scene: [{sceneId}]");
            EventBus.Publish(new EndSceneEvent(sceneId));

            FeatureLocator.Get<TickerFeature>().OnNextFrame(() =>
            {
                var asyncOp = SceneManager.UnloadSceneAsync((int)sceneId);
                asyncOp.completed += _ =>
                {
                    onComplete.Invoke();
                };
            });
        }

        #endregion

        #region UTIL

        private void Log(string message)
        {
            GameLog.Log($"[{nameof(SceneService)}] {message}");
        }

        private void Error(string message)
        {
            GameLog.Error($"[{nameof(SceneService)}] {message}");
        }
        #endregion
    }
}
