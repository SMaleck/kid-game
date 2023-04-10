using UnityEngine;

namespace Game.Utility.Pooling
{
    public class AudioSourcePool
    {
        private readonly PassiveObjectPool<AudioSource> _pool;

        public AudioSourcePool(AudioSource prefab)
        {
            _pool = new PassiveObjectPool<AudioSource>(prefab, IsFree);
        }

        public void Spawn(Vector3 position)
        {
            var instance = _pool.Spawn();

            instance.transform.position = position;
            instance.Play();
        }

        private static bool IsFree(AudioSource audioSource)
        {
            return !audioSource.isPlaying;
        }
    }
}
