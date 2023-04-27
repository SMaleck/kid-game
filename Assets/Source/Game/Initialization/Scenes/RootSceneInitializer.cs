﻿using Game.Initialization.ScriptableObjects;
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
            Screen.sleepTimeout = SleepTimeout.NeverSleep;

            _dataInitializer.Initialize();

            ServiceInitializer.Initialize();
            GameInitializer.Initialize();
        }

        protected override void StartInternal()
        {
            GameInitializer.Start();
            ServiceLocator.Get<SceneService>().InitialLoad();
        }
    }
}