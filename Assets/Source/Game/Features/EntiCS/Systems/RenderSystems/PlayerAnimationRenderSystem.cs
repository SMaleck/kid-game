using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.EntiCS.Components.Render;
using Game.Features.EntiCS.Components.Tags;
using Game.Features.EntiCS.Systems.BaseSystems;
using System;

namespace Game.Features.EntiCS.Systems.RenderSystems
{
    public class PlayerAnimationRenderSystem : PerEntitySystem
    {
        public override Type[] Filter { get; } = new[]
        {
            typeof(PlayerTagComponent),
            typeof(PlayerAnimationRenderComponent),
            typeof(JumpComponent),
            typeof(MovementComponent)
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            var jumping = entity.Get<JumpComponent>();
            var movement = entity.Get<MovementComponent>();
            var animation = entity.Get<PlayerAnimationRenderComponent>();

            if (!jumping.LastIsJumping && jumping.IsJumping)
            {
                animation.Jump();
            }

            animation.Velocity = (int)movement.Speed;
        }
    }
}
