using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.EntiCS.Components.Tags;
using Game.Features.EntiCS.Systems.BaseSystems;
using Game.Static.Events;
using Game.Static.Events.Dtos;
using System;
using UnityEngine;

namespace Game.Features.EntiCS.Systems.LateSystems
{
    public class PlayerLifecycleSystem : PerEntityLateSystem
    {
        public override Type[] Filter { get; } =
        {
            typeof(PlayerTagComponent),
            typeof(ColliderComponent),
            typeof(MovementComponent)
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            var collider = entity.Get<ColliderComponent>();
            for (var i = collider.Entered.Count - 1; i >= 0; i--)
            {
                var other = collider.Entered[i];
                if (other != null && other.Entity.Has<EndTriggerTagComponent>())
                {
                    entity.Get<MovementComponent>().MoveIntent = Vector3.zero;
                    EventBus.Publish(new PlayerTouchedLevelEndEvent());
                }
            }
        }
    }
}
