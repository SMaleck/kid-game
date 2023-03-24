using EntiCS.Entities.Components;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class MovementComponent : EntityComponent
    {
        [field: SerializeField] public Vector3 MoveIntent { get; set; }
        [field: SerializeField] public Vector3 TurnIntent { get; set; }
        [field: SerializeField] public float Speed { get; set; }
    }
}
