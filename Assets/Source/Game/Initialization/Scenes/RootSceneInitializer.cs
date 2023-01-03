using Game.Initialization.ScriptableObjects;
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
        }

        protected override void StartInternal()
        {
            ServiceLocator.Get<SceneService>().To(SceneId.Title);
        }
    }
}
