using EntiCS.Entities;
using Game.Features.EntiCS.Components.Render;
using Game.Features.EntiCS.Components.Tags;
using Game.Features.EntiCS.Systems.BaseSystems;
using System;

namespace Game.Features.EntiCS.Systems.RenderSystems
{
    public class PickupEffectRenderSystem : PerEntitySystem
    {
        public override Type[] Filter { get; } = new[]
        {
            typeof(PickupTagComponent),
            typeof(PickupEffectRenderComponent),
            typeof(SpecialEffectQueueComponent)
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            var effects = entity.Get<PickupEffectRenderComponent>();
            var eventQueue = entity.Get<SpecialEffectQueueComponent>();

            if (eventQueue.Effects.Contains(SpecialEffectType.Kill))
            {
                effects.PickupSE.Play();
            }
        }
    }
}
