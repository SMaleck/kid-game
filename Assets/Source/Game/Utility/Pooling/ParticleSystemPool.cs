using UnityEngine;

namespace Game.Utility.Pooling
{
    public class ParticleSystemPool
    {
        private readonly PassiveObjectPool<ParticleSystem> _pool;

        public ParticleSystemPool(ParticleSystem prefab)
        {
            _pool = new PassiveObjectPool<ParticleSystem>(prefab, IsFree);
        }

        public void Spawn(Vector3 position)
        {
            var instance = _pool.Spawn();

            instance.transform.position = position;
            instance.Play();
        }

        private static bool IsFree(ParticleSystem ps)
        {
            return !ps.isPlaying;
        }
    }
}
