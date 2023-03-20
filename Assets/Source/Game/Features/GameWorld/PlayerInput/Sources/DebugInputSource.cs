using EntiCS.Ticking;
using Game.Features.Ticking;
using Game.Static.Locators;
using System;
using UnityEngine;

namespace Game.Features.GameWorld.PlayerInput.Sources
{
    public class DebugInputSource : Feature, IPlayerInputSource, IUpdateable
    {
        public Action OnJump { get; set; }
        public Action OnRoll { get; set; }
        public Action OnPauseGame { get; set; }

        public override void OnStart()
        {
            FeatureLocator.Get<PlayerInputFeature>().Add(this);
            FeatureLocator.Get<TickerFeature>().SceneTicker.AddUpdate(this);
        }

        public override void OnEnd()
        {
            FeatureLocator.Get<TickerFeature>().SceneTicker.RemoveUpdate(this);
        }
        
        public void Update(float elapsedSeconds)
        {
            if (Input.GetKeyDown("a"))
            {
                OnJump();
            }
        }
    }
}
