using Game.Features.Ticking;
using Game.Static.Locators;
using UnityEngine;

namespace Game.Features.GameWorld
{
    // ToDo This should be event-based, so we don't check every frame whether to pause the PS.
    // Acceptable in this small-scale project
    public class AnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator _target;

        private TickerFeature _tickerFeature;
        private bool _lastPauseState;

        private void Start()
        {
            _tickerFeature = FeatureLocator.Get<TickerFeature>();
            _lastPauseState = _tickerFeature.SceneTicker.IsPaused;

            UpdateTargetSpeed();
        }

        private void Update()
        {
            if (_lastPauseState != _tickerFeature.SceneTicker.IsPaused)
            {
                UpdateTargetSpeed();
            }

            _lastPauseState = _tickerFeature.SceneTicker.IsPaused;
        }

        private void UpdateTargetSpeed()
        {
            var targetSpeed = _tickerFeature.SceneTicker.IsPaused ? 0f : 1f;
            _target.speed = targetSpeed;
        }

        private void OnValidate()
        {
            _target = GetComponent<Animator>();
        }
    }
}
