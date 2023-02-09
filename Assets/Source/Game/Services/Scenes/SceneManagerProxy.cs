﻿using Game.Services.Scenes.Events;
using Game.Static.Events;
using Game.Utility;
using System;
using UnityEngine.SceneManagement;

namespace Game.Services.Scenes
{
    public static class SceneManagerProxy
    {
        public static Scene CurrentScene { get; private set; }
        public static int CurrentSceneIndex { get; private set; }
        public static SceneId CurrentSceneId { get; private set; }
        public static int SceneCount => SceneManager.sceneCount;

        public static void Init()
        {
            UpdateCurrentSceneState();
        }

        public static void ReloadCurrent()
        {
            if (SceneManager.sceneCount < 2)
            {
                Error("Current scene is the only one loaded. Ignoring reload attempt.");
                return;
            }

            var sceneId = CurrentSceneId;

            EventBus.Publish(new BeforeSceneUnloadEvent(CurrentSceneId));
            var asyncOp = SceneManager.UnloadSceneAsync(CurrentSceneIndex);

            asyncOp.completed += _ =>
            {
                LoadAndSwitchScene(sceneId, false, null);
            };
        }

        public static void LoadAndSwitchScene(SceneId sceneId, bool unloadCurrent, Action onComplete)
        {
            var switchEvent = new SceneSwitchEvent(CurrentSceneId, sceneId);
            Log($"Starting Scene Load: [{switchEvent.From}] -> [{switchEvent.To}]");

            EventBus.Publish(switchEvent);
            if (unloadCurrent)
            {
                EventBus.Publish(new BeforeSceneUnloadEvent(CurrentSceneId));
            }

            var sceneLoad = SceneManager.LoadSceneAsync((int)sceneId, LoadSceneMode.Additive);
            sceneLoad.completed += _ =>
            {
                SwitchToScene(switchEvent, unloadCurrent);
                UpdateCurrentSceneState();
                onComplete.Invoke();
            };
        }

        private static void SwitchToScene(SceneSwitchEvent switchEvent, bool unloadCurrent)
        {
            Log($"Scene Load Complete. Switching: [{switchEvent.From}] -> [{switchEvent.To}]");

            var fromScene = SceneManager.GetSceneByName(switchEvent.From.ToSceneName());
            var toScene = SceneManager.GetSceneByName(switchEvent.To.ToSceneName());

            if (unloadCurrent)
            {
                SceneManager.UnloadSceneAsync(fromScene);
            }

            SceneManager.SetActiveScene(toScene);
        }

        private static void UpdateCurrentSceneState()
        {
            CurrentScene = SceneManager.GetActiveScene();
            CurrentSceneIndex = CurrentScene.buildIndex;
            CurrentSceneId = (SceneId)CurrentSceneIndex;
        }

        private static void Log(string message)
        {
            GameLog.Log($"[SCENES] {message}");
        }

        private static void Error(string message)
        {
            GameLog.Error($"[SCENES] {message}");
        }
    }
}
