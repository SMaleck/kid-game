using Game.Services.Scenes;
using Game.Static.Events;
using Game.Static.Locators;
using System;
using Game.Services.Scenes.Events;
using UnityEngine;

namespace Game.Features
{
    [RequireComponent(typeof(MonoFeature))]
    public class FeatureAutoInitializer : MonoBehaviour
    {
        [SerializeField] private MonoFeature _feature;

        private Type _registeredAsType;

        private void OnValidate()
        {
            _feature ??= GetComponent<MonoFeature>();
        }

        private void Awake()
        {
            _registeredAsType = _feature.GetType();
            FeatureLocator.Register(_registeredAsType, _feature);
            EventBus.OnEvent<BeforeSceneUnloadEvent>(BeforeSceneUnload);
        }

        private void Start()
        {
            _feature.OnStart();
        }

        private void BeforeSceneUnload(object eventArgs)
        {
            var args = (BeforeSceneUnloadEvent)eventArgs;
            if (args.Scene != gameObject.scene.ToSceneId())
            {
                return;
            }

            EventBus.Unsubscribe(BeforeSceneUnload);
            FeatureLocator.Remove(_registeredAsType);
            _feature.OnEnd();
        }
    }
}
