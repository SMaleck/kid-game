using EntiCS.Ticking;
using Game.Features.GameWorld.Levels.ProgressStrategies;
using Game.Features.Ticking;
using Game.Static.Locators;
using System;
using UnityEngine;

namespace Game.Features.GameWorld.Levels
{
    public class LevelStateFeature : MonoFeature, IUpdateable
    {
        [SerializeField] private LevelProgressStrategy _progressStrategy;

        public float MinProgress => _progressStrategy.MinProgress;
        public float MaxProgress => _progressStrategy.MaxProgress;
        public float Progress => _progressStrategy.Progress;
        public float RelativeProgress => _progressStrategy.RelativeProgress;
        public bool IsComplete => _progressStrategy.IsComplete;

        public Action OnComplete { get; set; }

        public override void OnStart()
        {
            _progressStrategy.OnStart();

            FeatureLocator.Get<TickerFeature>().Ticker
                .AddFixedUpdate(this);
        }

        private void EndStrategy()
        {
            FeatureLocator.Get<TickerFeature>().Ticker
                .RemoveFixedUpdate(this);

            _progressStrategy.OnEnd();
        }

        void IUpdateable.Update(float elapsedSeconds)
        {
            _progressStrategy.OnUpdate(elapsedSeconds);

            if (IsComplete)
            {
                EndStrategy();
                OnComplete?.Invoke();
            }
        }
    }
}
