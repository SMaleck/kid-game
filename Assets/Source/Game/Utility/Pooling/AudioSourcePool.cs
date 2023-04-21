using System.Collections.Generic;
using UnityEngine;
using UtilitiesGeneral.UnityExtensions;

namespace Game.Utility.Pooling
{
    public class AudioSourcePool
    {
        private readonly Transform _parent;
        private readonly PassiveObjectPool<AudioSource> _pool;
        private readonly HashSet<AudioSource> _instances;

        public IReadOnlyCollection<AudioSource> Instances => _instances;

        public AudioSourcePool(AudioSource prefab, Transform parent)
        {
            _parent = parent;
            _pool = new PassiveObjectPool<AudioSource>(prefab, IsFree);
            _instances = new HashSet<AudioSource>();
        }

        public void Spawn(AudioClip audioClip, bool loop, float volume, Vector3 position)
        {
            var instance = _pool.Spawn();
            instance.gameObject.SetParent(_parent);

            instance.clip = audioClip;
            instance.loop = loop;
            instance.volume = volume;
            instance.transform.position = position;

            _instances.Add(instance);
            instance.Play();
        }

        private static bool IsFree(AudioSource audioSource)
        {
            return !audioSource.isPlaying;
        }
    }
}
