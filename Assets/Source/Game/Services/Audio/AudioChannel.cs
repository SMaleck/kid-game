using Game.Utility.Pooling;
using UnityEngine;

namespace Game.Services.Audio
{
    public class AudioChannel
    {
        private readonly AudioChannelSettings _settings;
        private readonly AudioSourcePool _pool;

        public AudioChannelId ChannelId { get; }

        public AudioChannel(
            AudioChannelId channelId,
            AudioChannelSettings settings,
            AudioSource audioSourcePrefab,
            Transform audioRoot)
        {
            ChannelId = channelId;
            _settings = settings;
            _pool = new AudioSourcePool(audioSourcePrefab, audioRoot);
        }

        public void Play(AudioClip clip, bool loop, Vector3 position)
        {
            _pool.Spawn(clip, loop, _settings.Volume, position);
        }

        public void SetVolume(float volume)
        {
            foreach (var instance in _pool.Instances)
            {
                instance.volume = volume;
            }
        }

        public void Stop()
        {
            foreach (var instance in _pool.Instances)
            {
                instance.Stop();
            }
        }
    }
}
