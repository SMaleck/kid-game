using Game.Static.Locators;
using System;
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

            _simpleJumpButton.onClick.AddListener(() => OnJump());
            _jumpButton.onClick.AddListener(() => OnJump());
            _rollButton.onClick.AddListener(() => OnRoll());
            _pauseButton.onClick.AddListener(() => OnPauseGame());
        }

        public override void OnEnd()
        {
            FeatureLocator.Get<PlayerInputFeature>().Remove(this);
        }
    }
}
