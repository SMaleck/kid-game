using Game.Utility;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Services.Audio
{
    [CreateAssetMenu(menuName = ProjectConst.MenuData + nameof(AudioServiceSettingsSO), fileName = nameof(AudioServiceSettingsSO))]
    public class AudioServiceSettingsSO : ScriptableObject, IAudioServiceSettings
    {
        [SerializeField] private AudioServiceSettings _settingsObject;

        public List<AudioChannelSettings> Settings => _settingsObject.Settings;
        public AudioChannelSettings this[AudioChannelId channel] => _settingsObject[channel];
    }
}
