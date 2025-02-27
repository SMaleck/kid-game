﻿using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.EntiCS.Components.Tags;
using Game.Features.EntiCS.Systems.BaseSystems;
using Game.Features.GameWorld.PlayerInput;
using Game.Static.Events;
using Game.Static.Events.Dtos;
using Game.Static.Locators;
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
            var lifecycle = entity.Get<LifecycleComponent>();
            if (!lifecycle.IsAlive)
            {
                // ToDo This should happen only once, currently every frame the player is dead in the world
                FeatureLocator.Get<PlayerInputFeature>().SetIsBlocked(true);
                return;
            }

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
