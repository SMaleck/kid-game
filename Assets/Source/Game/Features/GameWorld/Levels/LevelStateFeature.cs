using EntiCS.Ticking;
using Game.Features.GameWorld.Levels.Completion;
using Game.Features.GameWorld.Levels.ProgressStrategies;
using Game.Features.Ticking;
using Game.Services.Gooey;
using Game.Static.Locators;
using System;
using UnityEngine;

namespace Game.Features.GameWorld.Levels
{
    public class LevelStateFeature : MonoFeature, IUpdateable
    {
        [SerializeField] private LevelProgressStrategy _progressStrategy;

        private ITicker _ticker;

        public float MinProgress => _progressStrategy.MinProgress;
        public float MaxProgress => _progressStrategy.MaxProgress;
        public float Progress => _progressStrategy.Progress;
        public float RelativeProgress => _progressStrategy.RelativeProgress;
        public bool IsComplete => _progressStrategy.IsComplete;

        public Action OnComplete { get; set; }

        public override void OnStart()
        {
            _ticker = FeatureLocator.Get<TickerFeature>().SceneTicker;
            _ticker.SetIsPaused(false);
            _ticker.AddFixedUpdate(this);

            _progressStrategy.OnStart();
        }

        void IUpdateable.Update(float elapsedSeconds)
        {
            _progressStrategy.OnUpdate(elapsedSeconds);

            if (IsComplete)
            {
                EndStrategy();
            }
        }

        private void EndStrategy()
        {
            _ticker.SetIsPaused(true);
            _ticker.RemoveFixedUpdate(this);

            _progressStrategy.OnEnd();
            OnComplete?.Invoke();

            ServiceLocator.Get<GuiServiceProxy>()
                .TryShow<LevelCompletionModalController>();
        }
    }
}
