using Game.Services.Audio;
using Game.Static.Locators;
using Game.Utility.Extensions;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Features.EntiCS.Animations
{
    public class PlayerAnimationEventHandler : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> _stepAudioClips;
        [SerializeField] private List<AudioClip> _hammerAudioClips;

        private AudioService _audioService;

        private void Start()
        {
            _audioService = ServiceLocator.Get<AudioService>();
        }

        public void OnStep()
        {
            var clip = _stepAudioClips.GetRandom();
            _audioService.PlayEffect(clip, transform.position);
        }

        public void OnHammerStrike()
        {
            var clip = _hammerAudioClips.GetRandom();
            _audioService.PlayEffect(clip, transform.position);
        }

        public void OnAnimationEvent(AnimationEvent animationEvent)
        {
            switch (animationEvent.stringParameter)
            {
                case "Step1":
                case "Step2":
                    OnStep();
                    break;

                case "OnHammerStrike":
                    OnHammerStrike();
                    break;
            }
        }
    }
}
