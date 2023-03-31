using EntiCS.Entities.Components;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class MovementComponent : EntityComponent
    {
        [field: SerializeField] public Vector3 MoveIntent { get; set; }
        [field: SerializeField] public Vector3 TurnIntent { get; set; }
        [field: SerializeField] public float MaxSpeed { get; set; }
        
        public float Speed { get; set; }
        public bool HasMoveIntent => MoveIntent.magnitude > 0;
        public bool HasTurnIntent => MoveIntent.magnitude > 0;
    }
}
