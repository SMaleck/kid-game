using Game.Features.Ticking;
using Game.Static.Locators;
using UnityEngine;

namespace Game.Features.GameWorld
{
    // ToDo This should be event-based, so we don't check every frame whether to pause the PS.
    // Acceptable in this small-scale project
    public class ParticleManager : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _ps;

        private TickerFeature _tickerFeature;
        private bool _shouldResume;

        private void Start()
        {
            _tickerFeature = FeatureLocator.Get<TickerFeature>();
        }

        private void Update()
        {
            if (!_tickerFeature.SceneTicker.IsPaused &&
                _shouldResume)
            {
                _ps.Play();
                _shouldResume = false;
            }
            else if (_tickerFeature.SceneTicker.IsPaused &&
                     _ps.isPlaying)
            {
                _ps.Pause();
                _shouldResume = true;
            }
        }

        private void OnValidate()
        {
            _ps = GetComponent<ParticleSystem>();
        }
    }
}
