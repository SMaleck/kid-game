using EntiCS.Entities;
using Game.Features.EntityBehaviours.Behaviours;
using System.Collections.Generic;

namespace Game.Features.EntityBehaviours
{
    public class EntityBehaviourFeature : Feature
    {
        private readonly DefaultEntityBehaviour _default;
        private readonly IReadOnlyDictionary<EntityBehaviourType, BehaviourFactory> _factories;

        public EntityBehaviourFeature()
        {
            _default = new DefaultEntityBehaviour();
            _factories = new Dictionary<EntityBehaviourType, BehaviourFactory>()
            {
                { EntityBehaviourType.Player, new PlayerBehaviourFactory() }
            };
        }

        public IEntityBehaviour Create(EntityBehaviourType behaviourType, IEntity entity)
        {
            if (behaviourType == EntityBehaviourType.None)
            {
                return _default;
            }

            return _factories[behaviourType].Create(entity);
        }
    }
}
