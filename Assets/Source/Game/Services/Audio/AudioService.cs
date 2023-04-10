using Game.Static.Locators;
using UnityEngine;

namespace Game.Services.Audio
{
    public class AudioService : MonoService
    {
        [SerializeField] private Transform _audioRoot;

        private void Start()
        {
            ServiceLocator.Register<AudioService>(this);
        }

        public void PlayEffect(AudioClip clip, Vector3 position)
        {

        }

        public void Play(AudioChannel channel, AudioClip clip, bool loop, Vector3 position)
        {

        }
    }
}
