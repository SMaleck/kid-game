using EntiCS.Entities.Components;
using Game.Features.EntiCS.Utility;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class JumpComponent : EntityComponent, IResettable
    {
        [field: SerializeField] public float MaxJumpHeight { get; set; }

        public bool HasJumpIntent { get; set; }
        public bool IsJumping { get; set; }
        public float StartY { get; set; }
        public float JumpSpeed { get; set; }
        public float ElapsedSeconds { get; set; }
        
        public void ResetState()
        {
            HasJumpIntent = default;
            IsJumping = default;
            StartY = default;
            ElapsedSeconds = default;
        }
    }
}
