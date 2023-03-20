using EntiCS.Ticking;
using EntiCS.Utility;
using Game.Features.Ticking;
using Game.Static.Locators;
using System;
using UnityEngine;

namespace Game.Features.GameWorld.PlayerInput.Sources
{
    public class KeyboardInputSource : Feature, IPlayerInputSource
    {
        private static readonly KeyCode[] JumpKeys =
        {
            // Space and surrounding Keys
            KeyCode.Space,
            KeyCode.LeftAlt,
            KeyCode.RightAlt,
            KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M,

            // Alternatives
            KeyCode.UpArrow,
        };

        private static readonly KeyCode[] RollKeys =
        {
            KeyCode.DownArrow,
            KeyCode.LeftControl,
            KeyCode.LeftShift
        };

        private static readonly KeyCode[] PauseKeys =
        {
            KeyCode.Escape,
            KeyCode.Pause,
            KeyCode.P
        };

        public Action OnJump { get; set; }
        public Action OnRoll { get; set; }
        public Action OnPauseGame { get; set; }

        private IUpdateable _sceneProxy;
        private IUpdateable _engineProxy;

        public override void OnStart()
        {
            FeatureLocator.Get<PlayerInputFeature>().Add(this);

            var tickerFeature = FeatureLocator.Get<TickerFeature>();

            _engineProxy = new UpdateableProxy(OnEngineUpdate);
            tickerFeature.EngineTicker.AddUpdate(_engineProxy);

            _sceneProxy = new UpdateableProxy(OnSceneUpdate);
            tickerFeature.SceneTicker.AddUpdate(_sceneProxy);
        }

        public override void OnEnd()
        {
            FeatureLocator.Get<PlayerInputFeature>().Remove(this);

            var tickerFeature = FeatureLocator.Get<TickerFeature>();
            tickerFeature.EngineTicker.RemoveUpdate(_engineProxy);
            tickerFeature.SceneTicker.RemoveUpdate(_sceneProxy);
        }

        private void OnEngineUpdate(float elapsedSeconds)
        {
            if (!Input.anyKeyDown)
            {
                return;
            }


            for (var i = 0; i < PauseKeys.Length; i++)
            {
                if (Input.GetKeyDown(PauseKeys[i]))
                {
                    OnPauseGame();
                    return;
                }
            }
        }

        private void OnSceneUpdate(float elapsedSeconds)
        {

            for (var i = 0; i < JumpKeys.Length; i++)
            {
                if (Input.GetKeyDown(JumpKeys[i]))
                {
                    OnJump();
                    return;
                }
            }

            for (var i = 0; i < RollKeys.Length; i++)
            {
                if (Input.GetKeyDown(RollKeys[i]))
                {
                    OnRoll();
                    return;
                }
            }
        }
    }
}
