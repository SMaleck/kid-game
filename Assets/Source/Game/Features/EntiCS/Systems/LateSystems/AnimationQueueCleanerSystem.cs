using EntiCS.Entities;
using Game.Features.EntiCS.Components.Render;
using Game.Features.EntiCS.Systems.BaseSystems;
using System;

namespace Game.Features.EntiCS.Systems.LateSystems
{
    public class AnimationQueueCleanerSystem : PerEntityLateSystem
    {
        public override int ExecutionOrder { get; } = 1000;

        public override Type[] Filter { get; } = new[]
        {
            typeof(PlayerEventQueueComponent)
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            entity.Get<PlayerEventQueueComponent>().Clean();
        }
    }
}
