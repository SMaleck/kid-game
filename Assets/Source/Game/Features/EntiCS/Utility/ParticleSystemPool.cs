using System.Collections.Generic;
using UnityEngine;

namespace Game.Features.EntiCS.Utility
{
    public class ParticleSystemPool
    {
        private readonly ParticleSystem _prefab;

        private readonly List<ParticleSystem> _free = new List<ParticleSystem>();
        private readonly List<ParticleSystem> _active = new List<ParticleSystem>();

        public ParticleSystemPool(ParticleSystem prefab)
        {
            _prefab = prefab;
        }

        public void Spawn(Vector3 position)
        {
            var instance = GetOrCreate();
            _active.Add(instance);

            instance.transform.position = position;
            instance.Play();
        }

        private ParticleSystem GetOrCreate()
        {
            SanitizeActive();

            if (_free.Count > 0)
            {
                var instance = _free[0];
                _free.RemoveAt(0);

                return instance;
            }
            
            return Create();
        }

        private ParticleSystem Create()
        {
            var instance = GameObject.Instantiate<ParticleSystem>(_prefab);
            return instance;
        }

        private void SanitizeActive()
        {
            for (var i = _active.Count - 1; i >= 0; i--)
            {
                var instance = _active[i];
                if (!instance.isPlaying)
                {
                    _free.Add(instance);
                    _active.RemoveAt(i);
                }
            }
        }
    }
}
