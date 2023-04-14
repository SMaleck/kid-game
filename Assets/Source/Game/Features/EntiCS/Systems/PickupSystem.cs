using System;
using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.EntiCS.Components.Generic;
using Game.Features.EntiCS.Components.Render;
using Game.Features.EntiCS.Components.Tags;
using Game.Features.EntiCS.Systems.BaseSystems;

namespace Game.Features.EntiCS.Systems
{
    public class PickupSystem : PerEntitySystem
    {
        public override Type[] Filter { get; } =
        {
            typeof(PickupTagComponent),
            typeof(ISensorComponent),
            typeof(SpecialEffectQueueComponent),
            typeof(VisibilityComponent)
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            var collider = entity.Get<ISensorComponent>();
            for (var i = collider.Entered.Count - 1; i >= 0; i--)
            {
                var other = collider.Entered[i];
                if (other != null && other.Entity.Has<PlayerTagComponent>())
                {
                    entity.Get<SpecialEffectQueueComponent>().Add(SpecialEffectType.Kill);
                    entity.Get<VisibilityComponent>().IsVisible = false;
                }
            }
        }
    }
}
