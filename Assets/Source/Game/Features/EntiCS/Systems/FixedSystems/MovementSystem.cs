using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.EntiCS.Systems.BaseSystems;
using System;

namespace Game.Features.EntiCS.Systems.FixedSystems
{
    public class MovementSystem : PerEntityFixedSystem
    {
        public override Type[] Filter { get; } = new[]
        {
            typeof(TransformComponent),
            typeof(MovementComponent)
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            var transform = entity.Get<TransformComponent>();
            var movement = entity.Get<MovementComponent>();

            movement.Speed = movement.HasMoveIntent ? movement.MaxSpeed : 0f;

            transform.Transform.position += movement.MoveIntent *
                                            movement.Speed *
                                            (float)elapsedSeconds;
        }
    }
}
