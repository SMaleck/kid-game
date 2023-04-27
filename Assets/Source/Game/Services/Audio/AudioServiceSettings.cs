using System;
using System.Collections.Generic;
using System.Linq;
using Game.Utility;
using UnityEngine;

namespace Game.Services.Audio
{
    [Serializable]
    public class AudioChannelSettings
    {
        public AudioChannelId Channel;

        [UnityEngine.Range(0f, 1f)]
        public float Volume;
    }

    [CreateAssetMenu(menuName = ProjectConst.MenuData + nameof(AudioServiceSettings), fileName = nameof(AudioServiceSettings))]
    public class AudioServiceSettings : ScriptableObject
    {
        public List<AudioChannelSettings> Settings;
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
