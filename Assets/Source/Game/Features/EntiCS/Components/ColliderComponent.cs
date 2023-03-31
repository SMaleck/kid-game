using EntiCS.Entities;
using EntiCS.Entities.Components;
using Game.Features.EntiCS.Components.Generic;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Features.EntiCS.Components
{
    public class ColliderComponent : MonoEntityComponent, ISensorComponent, ISensorTarget
    {
        [SerializeField] private MonoEntity _entity;
        IEntity ISensorTarget.Entity => _entity;

        private readonly List<ISensorTarget> _known = new();
        public IReadOnlyList<ISensorTarget> Known => _known;

        private readonly List<ISensorTarget> _entered = new();
        public IReadOnlyList<ISensorTarget> Entered => _entered;

        private readonly List<ISensorTarget> _exited = new();
        public IReadOnlyList<ISensorTarget> Exited => _exited;

        private void OnTriggerEnter(Collider other)
        {
            var otherCollider = other.GetComponent<ISensorTarget>();
            if (otherCollider == null)
            {
                return;
            }

            if (!_known.Contains(otherCollider))
            {
                _known.Add(otherCollider);
            }
            if (!_entered.Contains(otherCollider))
            {
                _entered.Add(otherCollider);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            var otherCollider = other.GetComponent<ISensorTarget>();
            if (otherCollider == null)
            {
                return;
            }

            if (_known.Contains(otherCollider))
            {
                _known.Remove(otherCollider);
            }
            if (!_exited.Contains(otherCollider))
            {
                _exited.Add(otherCollider);
            }
        }

        public void Clean()
        {
            _entered.Clear();
            _exited.Clear();
        }

        public void ResetState()
        {
            Clean();
            _known.Clear();
        }
    }
}
