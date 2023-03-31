using System;
using EntiCS.Entities;
using Game.Features.EntiCS.Components.Generic;
using Game.Features.EntiCS.Systems.BaseSystems;

namespace Game.Features.EntiCS.Systems.LateSystems
{
    public class SensorCleanSystem : PerEntityLateSystem
    {
        public override int ExecutionOrder { get; } = 1000;

        public override Type[] Filter { get; } = new[]
        {
            typeof(ISensorComponent)
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            entity.Get<ISensorComponent>().Clean();
        }
    }
}
