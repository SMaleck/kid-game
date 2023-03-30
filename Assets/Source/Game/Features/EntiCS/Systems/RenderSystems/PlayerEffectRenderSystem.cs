using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.EntiCS.Components.Tags;
using Game.Features.EntiCS.Systems.BaseSystems;
using System;
using Game.Features.EntiCS.Components.Render;

namespace Game.Features.EntiCS.Systems.RenderSystems
{
    public class PlayerEffectRenderSystem : PerEntitySystem
    {
        public override Type[] Filter { get; } = new[]
        {
            typeof(PlayerTagComponent),
            typeof(PlayerEffectRenderComponent),
            typeof(JumpComponent)
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            var jumping = entity.Get<JumpComponent>();
            var effects = entity.Get<PlayerEffectRenderComponent>();
            if (jumping.LastIsJumping != jumping.IsJumping)
            {
                effects.PlayDust();
            }
        }
    }
}
