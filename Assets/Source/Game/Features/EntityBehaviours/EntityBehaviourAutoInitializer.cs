using EntiCS.Entities;
using Game.Features.EntityBehaviours.Behaviours;
using Game.Services.Scenes;
using Game.Services.Scenes.Events;
using Game.Static.Events;
using Game.Static.Locators;
using UnityEngine;

namespace Game.Features.EntityBehaviours
{
    public class EntityBehaviourAutoInitializer : MonoBehaviour
    {
        [SerializeField] private EntityBehaviourType _behaviourType;

        private IEntity _entity;
        private string _sceneName;
        private IEntityBehaviour _behaviour;

        private void Start()
        {
            _entity = GetComponent<IEntity>();
            _sceneName = gameObject.scene.name;

            _behaviour = FeatureLocator.Get<EntityBehaviourFeature>().Create(_behaviourType, _entity);
            _behaviour.Start();

            EventBus.OnEvent<EndSceneEvent>(Deregister);
        }

        private void Deregister(object eventArgs)
        {
            if (eventArgs is EndSceneEvent endSceneEvent &&
                endSceneEvent.Scene.ToSceneName() == _sceneName)
            {
                Cleanup();
            }
        }

        private void OnDestroy()
        {
            if (_entity != null)
            {
                Cleanup();
            }
        }

        private void Cleanup()
        {
            EventBus.Unsubscribe(Deregister);

            _behaviour.Stop();
            _behaviour.Dispose();
            _behaviour = null;
        }
    }
}
