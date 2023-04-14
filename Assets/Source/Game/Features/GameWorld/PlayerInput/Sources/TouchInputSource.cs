using Game.Features.Ticking;
using Game.Static.Locators;
using System;
using Game.Features.LevelSelection;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Features.GameWorld.PlayerInput.Sources
{
    public class TouchInputSource : MonoFeature, IPlayerInputSource
    {
        [SerializeField] private Button _simpleJumpButton;
        [SerializeField] private Button _jumpButton;
        [SerializeField] private Button _rollButton;
        [SerializeField] private Button _pauseButton;

        public Action OnJump { get; set; }
        public Action OnRoll { get; set; }
        public Action OnPauseGame { get; set; }

        public override void OnStart()
        {
            FeatureLocator.Get<PlayerInputFeature>().Add(this);

            var ticker = FeatureLocator.Get<TickerFeature>().SceneTicker;

            _simpleJumpButton.onClick.AddListener(() =>
            {
                if (!ticker.IsPaused)
                    OnJump();
            });

            _jumpButton.onClick.AddListener(() =>
            {
                if (!ticker.IsPaused)
                    OnJump();
            });

            _rollButton.onClick.AddListener(() =>
            {
                if (!ticker.IsPaused)
                    OnRoll();
            });

            _pauseButton.onClick.AddListener(() => OnPauseGame());

            var complexity = FeatureLocator.Get<LevelSelectFeature>().Complexity;
            var isRollingEnabled = complexity > LevelComplexity.C2;

            _simpleJumpButton.gameObject.SetActive(!isRollingEnabled);
            _jumpButton.gameObject.SetActive(isRollingEnabled);
            _rollButton.gameObject.SetActive(isRollingEnabled);
        }
    }
}
