using EntiCS.Entities;
using Game.Features.EntiCS.Components;
using Game.Features.EntiCS.Components.Render;
using Game.Features.EntiCS.Systems.BaseSystems;
using System;
using UnityEngine;

namespace Game.Features.EntiCS.Systems.FixedSystems
{
    public class JumpSystem : PerEntityFixedSystem
    {
        public override Type[] Filter { get; } = new[]
        {
            typeof(TransformComponent),
            typeof(JumpComponent),
            typeof(SpecialEffectQueueComponent)
        };

        protected override void UpdateEntity(float elapsedSeconds, IEntity entity)
        {
            var jumping = entity.Get<JumpComponent>();
            jumping.LastIsJumping = jumping.IsJumping;

            if (!jumping.HasJumpIntent && !jumping.IsJumping)
            {
                return;
            }

            var transform = entity.Get<TransformComponent>();
            var eventQueue = entity.Get<SpecialEffectQueueComponent>();
            JumpTick(elapsedSeconds, transform, jumping, eventQueue);
        }

        private void JumpTick(
            float elapsedSeconds,
            TransformComponent transform,
            JumpComponent jumping,
            SpecialEffectQueueComponent eventQueue)
        {
            if (jumping.HasJumpIntent && !jumping.IsJumping)
            {
                jumping.StartY = transform.Position.y;
                jumping.IsJumping = true;
                var jumpSpeed = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * jumping.MaxJumpHeight) / jumping.MaxJumpHeight;
                jumping.JumpSpeed = jumpSpeed * jumping.JumpSpeedFactor;

                eventQueue.Add(SpecialEffectType.JumpStart);
            }

            jumping.ElapsedSeconds += elapsedSeconds;
            float yOffset = jumping.MaxJumpHeight * Mathf.Sin(jumping.ElapsedSeconds * jumping.JumpSpeed);

            var previousOffset = transform.Position.y - jumping.StartY;
            if (!jumping.HasPassedApex &&
                previousOffset > yOffset)
            {
                jumping.HasPassedApex = true;
                eventQueue.Add(SpecialEffectType.JumpApex);
            }

            var position = transform.Position;
            transform.Position = new Vector3(position.x, jumping.StartY + yOffset, position.z);

            TryEndJump(transform, jumping, eventQueue);
        }

        private void TryEndJump(TransformComponent transform, JumpComponent jumping, SpecialEffectQueueComponent eventQueue)
        {
            if (jumping.ElapsedSeconds >= Mathf.PI / jumping.JumpSpeed)
            {
                var position = transform.Position;
                transform.Position = new Vector3(position.x, jumping.StartY, position.z);

                jumping.ResetState();
                eventQueue.Add(SpecialEffectType.JumpEnd);
            }
        }
    }
}
