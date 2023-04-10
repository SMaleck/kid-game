using EntiCS.Entities;
using Game.Features.EntiCS.Components.Render;
using Game.Features.EntiCS.Components.Tags;
using Game.Features.EntiCS.Systems.BaseSystems;
using System;

namespace Game.Features.EntiCS.Systems.RenderSystems
{
    public class PlayerEffectRenderSystem : PerEntitySystem
    {
        public override Type[] Filter { get; } = new[]
        {
            typeof(PlayerTagComponent),
            typeof(PlayerEffectRenderComponent),
            typeof(PlayerEventQueueComponent)
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            var effects = entity.Get<PlayerEffectRenderComponent>();
            var eventQueue = entity.Get<PlayerEventQueueComponent>();

            if (eventQueue.Effects.Contains(PlayerEffectType.JumpStart))
            {
                effects.JumpStartSE.Play();
            }
            if (eventQueue.Effects.Contains(PlayerEffectType.JumpApex))
            {
                effects.JumpApexSE.Play();
            }
            if (eventQueue.Effects.Contains(PlayerEffectType.JumpEnd))
            {
                effects.JumpEndSE.Play();
            }
        }
    }
}
