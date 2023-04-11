using UnityEngine;
using UtilitiesGeneral.UnityExtensions;

namespace Game.Utility.Pooling
{
    public class AudioSourcePool
    {
        private readonly Transform _parent;
        private readonly PassiveObjectPool<AudioSource> _pool;

        public AudioSourcePool(AudioSource prefab, Transform parent)
        {
            _parent = parent;
            _pool = new PassiveObjectPool<AudioSource>(prefab, IsFree);
        }

        public void Spawn(AudioClip audioClip, bool loop, Vector3 position)
        {
            var instance = _pool.Spawn();
            instance.gameObject.SetParent(_parent);

            instance.clip = audioClip;
            instance.loop = loop;
            instance.transform.position = position;

            instance.Play();
        }

        private static bool IsFree(AudioSource audioSource)
        {
            return !audioSource.isPlaying;
        }
    }
}
