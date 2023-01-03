using EntiCS.Entities.Components;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class MovementComponent : MonoEntityComponent
    {
        public Vector3 MoveIntent { get; set; } = new Vector3(1, 0, 0);
        public Vector3 TurnIntent { get; set; }
    }
}
