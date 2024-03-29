﻿using Game.Services.Gooey;
using Game.Services.Scenes;
using Game.Static.Events;
using Game.Static.Locators;
using Gooey;
using System;
using System.Collections.Generic;
using Game.Services.Scenes.Events;
using UnityEngine;

namespace Game.Initialization.Scenes
{
    public abstract class SceneInitializer : MonoBehaviour
    {
        private class FeatureDto
        {
            public Type RegisteredAsType;
            public IFeature Feature;
        }

        private readonly List<FeatureDto> _registeredFeatures = new();
        private readonly List<IGui> _registeredGuis = new();

        protected SceneId Scene => gameObject.scene.ToSceneId();

        /// <summary>
        /// Runs internal init process for the scene.
        /// </summary>
        private void Awake()
        {
            EventBus.Publish(new StartSceneEvent(Scene));

            AwakeInternal();
        }

        private void Start()
        {
            EventBus.OnEvent<EndSceneEvent>(OnEndScene);

            StartInternal();

            // Start all features that were registered
            foreach (var feature in _registeredFeatures)
            {
                feature.Feature.OnStart();
            }
        }

        private void OnEndScene(object eventArgs)
        {
            var args = (EndSceneEvent)eventArgs;
            if (args.Scene != gameObject.scene.ToSceneId())
            {
                return;
            }

            foreach (var featureDto in _registeredFeatures)
            {
                FeatureLocator.Remove(featureDto.RegisteredAsType);
                featureDto.Feature.OnEnd();
            }

            foreach (var gui in _registeredGuis)
            {
                ServiceLocator.Get<GuiServiceProxy>().Remove(gui);
            }

            EventBus.Unsubscribe(OnEndScene);
            OnDestroyInternal();
        }

        protected abstract void AwakeInternal();
        protected virtual void StartInternal() { }
        protected virtual void OnDestroyInternal() { }

        protected void RegisterFeature<T>(IFeature feature) where T : IFeature
        {
            _registeredFeatures.Add(new FeatureDto()
            {
                RegisteredAsType = typeof(T),
                Feature = feature,
            });

            FeatureLocator.Register<T>(feature);
        }

        protected void RegisterGui<T>(IGui gui) where T : IGui
        {
            _registeredGuis.Add(gui);
            ServiceLocator.Get<GuiServiceProxy>().Add(gui);
        }
    }
}
