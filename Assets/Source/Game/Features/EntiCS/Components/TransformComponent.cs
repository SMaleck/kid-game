using EntiCS.Entities.Components;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class TransformComponent : EntityComponent
    {
        [SerializeField] private Transform _transform;

        public Transform Transform => _transform;

        public Vector3 Position
        {
            get => _transform.position;
            set => _transform.position = value;
        }

        public Vector3 Rotation
        {
            get => _transform.eulerAngles;
            set => _transform.eulerAngles = value;
        }
    }
}
