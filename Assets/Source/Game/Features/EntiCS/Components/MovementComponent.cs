using EntiCS.Entities.Components;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class MovementComponent : EntityComponent
    {
        public Vector3 MoveIntent { get; set; } = new Vector3(1, 0, 0);
        public Vector3 TurnIntent { get; set; }

        public bool IsJumping { get; set; }
        public Vector3 JumpStartPos { get; set; }
    }
}
