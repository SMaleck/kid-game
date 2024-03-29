﻿using EntiCS.Entities;
using Game.Services.Scenes;
using Game.Services.Scenes.Events;
using Game.Static.Events;
using Game.Static.Locators;
using UnityEngine;

namespace Game.Features.EntiCS.Utility
{
    /// <summary>
    /// Add this component to an EntiCS entity,
    /// to automatically add it to the current world
    /// </summary>
    public class EntityRegistrationComponent : MonoBehaviour
    {
        private IEntity _entity;
        private string _sceneName;

        private void Start()
        {
            _entity = GetComponent<IEntity>();
            _sceneName = gameObject.scene.name;

            FeatureLocator.Get<EnticsFeature>().AddEntity(_entity);
            EventBus.OnEvent<EndSceneEvent>(Deregister);
        }

        private void Deregister(object eventArgs)
        {
            if (eventArgs is EndSceneEvent endSceneEvent &&
                endSceneEvent.Scene.ToSceneName() == _sceneName)
            {
                FeatureLocator.GetOrDefault<EnticsFeature>()?.RemoveEntity(_entity);
            }
        }

        private void OnDestroy()
        {
            FeatureLocator.GetOrDefault<EnticsFeature>()?.RemoveEntity(_entity);
        }
    }
}
