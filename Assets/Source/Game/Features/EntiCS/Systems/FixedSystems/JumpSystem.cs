using EntiCS.Entities;
using Game.Features.EntiCS.Components;
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
            typeof(JumpComponent)
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
            JumpTick(elapsedSeconds, transform, jumping);
        }

        private void JumpTick(float elapsedSeconds, TransformComponent transform, JumpComponent jumping)
        {
            if (jumping.HasJumpIntent && !jumping.IsJumping)
            {
                jumping.StartY = transform.Position.y;
                jumping.IsJumping = true;
                var jumpSpeed = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * jumping.MaxJumpHeight) / jumping.MaxJumpHeight;
                jumping.JumpSpeed = jumpSpeed * jumping.JumpSpeedFactor;
            }
            
            jumping.ElapsedSeconds += elapsedSeconds;

            float yOffset = jumping.MaxJumpHeight * Mathf.Sin(jumping.ElapsedSeconds * jumping.JumpSpeed);

            var position = transform.Position;
            transform.Position = new Vector3(position.x, jumping.StartY + yOffset, position.z);

            TryEndJump(transform, jumping);
        }

        private void TryEndJump(TransformComponent transform, JumpComponent jumping)
        {
            if (jumping.ElapsedSeconds >= Mathf.PI / jumping.JumpSpeed)
            {
                var position = transform.Position;
                transform.Position = new Vector3(position.x, jumping.StartY, position.z);

                jumping.ResetState();
            }
        }
    }
}
