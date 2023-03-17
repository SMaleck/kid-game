using EntiCS.Entities.Components;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class MovementComponent : EntityComponent
    {
        private Vector3 _moveIntent = new Vector3(1, 0, 0);
        public Vector3 MoveIntent
        {
            get => _moveIntent;
            set
            {
                _moveIntent = value;
                Speed = value.magnitude;
            }
        }

        public Vector3 TurnIntent { get; set; }
        public float Speed { get; private set; }

        public bool IsJumping { get; set; }
        public Vector3 JumpStartPos { get; set; }
    }
}
