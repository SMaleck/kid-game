using Game.Static.Locators;
using UnityEngine;

namespace Game.Services.Audio
{
    public class AutoAudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioChannelId _channel;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private bool _loop;

        public void Start()
        {
            ServiceLocator.Get<AudioService>().Play(_channel, _audioClip, _loop, transform.position);
        }
    }
}
