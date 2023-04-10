using Game.Services.Audio;
using Game.Static.Locators;
using Game.Utility.Pooling;
using UnityEngine;

namespace Game.Features.EntiCS.Utility
{
    public class SpecialEffect : MonoBehaviour
    {
        [SerializeField] private Transform _slot;

        [Header("Particles")]
        [SerializeField] private bool _hasPS;
        [SerializeField] private ParticleSystem _psPrefab;

        [Header("Audio")]
        [SerializeField] private bool _hasAudio;
        [SerializeField] private AudioClip _audioClip;

        private ParticleSystemPool _particlePool;
        private ParticleSystemPool ParticlePool => _particlePool ??= new ParticleSystemPool(_psPrefab);

        private AudioService _audioService;
        private AudioService AudioService => _audioService ??= ServiceLocator.Get<AudioService>();

        public void Play()
        {
            if (_hasPS) ParticlePool.Spawn(_slot.position);
            if (_hasAudio) AudioService.PlayEffect(_audioClip, _slot.position);
        }
    }
}
