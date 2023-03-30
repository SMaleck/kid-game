using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.EntiCS.Components.Tags;
using Game.Features.EntiCS.Systems.BaseSystems;
using System;

namespace Game.Features.EntiCS.Systems.UpdateSystems
{
    public class PlayerEffectSystem : PerEntitySystem
    {
        public override Type[] Filter { get; } = new[]
        {
            typeof(PlayerTagComponent),
            typeof(PlayerEffectComponent),
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            var jumping = entity.Get<JumpComponent>();
            var effects = entity.Get<PlayerEffectComponent>();
            if (jumping.LastIsJumping != jumping.IsJumping)
            {
                effects.PlayDust();
            }
        }
    }
}
