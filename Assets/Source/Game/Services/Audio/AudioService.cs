using Game.Static.Locators;
using Game.Utility.Pooling;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Services.Audio
{
    public class AudioService : MonoService
    {
        [SerializeField] private Transform _audioRoot;
        [SerializeField] private AudioSource _musicChannelPrefab;
        [SerializeField] private AudioSource _effectChannelPrefab;
        [SerializeField] private AudioSource _uiChannelPrefab;

        private Dictionary<AudioChannel, AudioSourcePool> _pools;

        private void Start()
        {
            _pools = new Dictionary<AudioChannel, AudioSourcePool>()
            {
                { AudioChannel.Music, new AudioSourcePool(_musicChannelPrefab, transform)},
                { AudioChannel.Effects, new AudioSourcePool(_effectChannelPrefab, transform)},
                { AudioChannel.UI, new AudioSourcePool(_uiChannelPrefab, transform)}
            };

            ServiceLocator.Register<AudioService>(this);
        }

        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            Play(AudioChannel.UI, clip, loop, Vector3.zero);
        }

        public void PlayEffect(AudioClip clip, Vector3 position)
        {
            Play(AudioChannel.UI, clip, false, position);
        }

        public void PlayUI(AudioClip clip)
        {
            Play(AudioChannel.UI, clip, false, Vector3.zero);
        }

        public void Play(AudioChannel channel, AudioClip clip, bool loop, Vector3 position)
        {
            _pools[channel].Spawn(clip, loop, position);
        }
    }
}
