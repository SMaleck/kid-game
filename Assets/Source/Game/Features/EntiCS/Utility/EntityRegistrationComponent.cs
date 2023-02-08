using EntiCS.Entities;
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
        public IEntity Entity { get; private set; }
        public string SceneName { get; private set; }

        private void Start()
        {
            Entity = GetComponent<IEntity>();
            SceneName = gameObject.scene.name;

            FeatureLocator.Get<EnticsFeature>().AddEntity(Entity);
        }

        private void OnDestroy()
        {
            FeatureLocator.Get<EnticsFeature>().RemoveEntity(Entity);
        }
    }
}
