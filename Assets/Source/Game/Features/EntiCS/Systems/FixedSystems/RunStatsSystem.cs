using System;
using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.EntiCS.Systems.BaseSystems;

namespace Game.Features.EntiCS.Systems.FixedSystems
{
    public class RunStatsSystem : PerEntityFixedSystem
    {
        public override Type[] Filter { get; } =
        {
            typeof(RunStatsComponent),
            typeof(TransformComponent)
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            var runStatsComponent = entity.Get<RunStatsComponent>();
            var transformComponent = entity.Get<TransformComponent>();

            if (!runStatsComponent.StartedRecording)
            {
                runStatsComponent.StartedRecording = true;
                runStatsComponent.Origin = transformComponent.Position;
            }

            runStatsComponent.ElapsedDistanceUnits = transformComponent.Position.x - runStatsComponent.Origin.x;
            runStatsComponent.ElapsedSeconds += elapsedSeconds;
        }
    }
}
