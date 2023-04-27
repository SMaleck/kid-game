using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Services.Audio
{
    public interface IAudioServiceSettings
    {
        List<AudioChannelSettings> Settings { get; }
        AudioChannelSettings this[AudioChannelId channel] { get; }
    }

    [Serializable]
    public class AudioChannelSettings
    {
        public AudioChannelId Channel;

        [UnityEngine.Range(0f, 1f)]
        public float Volume;
    }

    [Serializable]
    public class AudioServiceSettings : IAudioServiceSettings
    {
        [field: SerializeField] public List<AudioChannelSettings> Settings { get; set; }
        public AudioChannelSettings this[AudioChannelId channel] => Cache[channel];

        private Dictionary<AudioChannelId, AudioChannelSettings> _cache;
        private Dictionary<AudioChannelId, AudioChannelSettings> Cache => _cache ??= Settings.ToDictionary(e => e.Channel);

        public AudioServiceSettings()
            : this(new List<AudioChannelSettings>())
        {
        }

        public AudioServiceSettings(List<AudioChannelSettings> settings)
        {
            Settings = settings;
        }
    }
}
