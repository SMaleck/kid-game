using EntiCS.Entities.Components;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class TransformComponent : MonoEntityComponent
    {
        [SerializeField] private Transform _transform;

        public Transform Transform => _transform;
        public Vector3 Position => _transform.position;
        public Vector3 Rotation => _transform.eulerAngles;
    }
}
