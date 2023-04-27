using Game.Static.Locators;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UtilitiesGeneral.Utilities;

namespace Game.Services.Audio
{
    public class AudioService : MonoService
    {
        [SerializeField] private Transform _audioRoot;
        [SerializeField] private AudioSource _audioPrefab;

        // ToDo Add settings storage, so user can change them
        [Header("Settings")]
        [SerializeField] private AudioServiceSettings _defaultSettings;
        private AudioServiceSettings _settings;

        private Dictionary<AudioChannelId, AudioChannel> _channels;

        private void Start()
        {
            _settings = new AudioServiceSettings(_defaultSettings.Settings);

            _channels = EnumIterator<AudioChannelId>.Iterator
                .ToDictionary(e => e, CreateChannel);
            
            ServiceLocator.Register<AudioService>(this);
        }

        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            Play(AudioChannelId.Music, clip, loop, Vector3.zero);
        }

        public void PlayEffect(AudioClip clip, Vector3 position)
        {
            Play(AudioChannelId.Effects, clip, false, position);
        }

        public void PlayUI(AudioClip clip)
        {
            Play(AudioChannelId.UI, clip, false, Vector3.zero);
        }

        public void PlayAmbient(AudioClip clip)
        {
            Play(AudioChannelId.Ambient, clip, true, Vector3.zero);
        }

        public void Play(AudioChannelId channel, AudioClip clip, bool loop, Vector3 position)
        {
            _channels[channel].Play(clip, loop, position);
        }

        private AudioChannel CreateChannel(AudioChannelId channelId)
        {
            return new AudioChannel(
                channelId,
                _settings[channelId],
                _audioPrefab,
                transform);
        }
    }
}
