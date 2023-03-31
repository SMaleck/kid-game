using EntiCS.Ticking;
using Game.Features.GameWorld.Levels.ProgressStrategies;
using Game.Features.Ticking;
using Game.Features.UI.Completion;
using Game.Services.Gooey;
using Game.Static.Events;
using Game.Static.Events.Dtos;
using Game.Static.Locators;
using System;
using UnityEngine;

namespace Game.Features.GameWorld.Levels
{
    public class LevelStateFeature : MonoFeature, IUpdateable
    {
        [SerializeField] private LevelProgressStrategy _progressStrategy;
        [SerializeField] private LevelStartArea _levelStartArea;
        [SerializeField] private LevelEndArea _levelEndArea;

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

            _levelStartArea.OnComplete += () => _progressStrategy.OnStart();
            _levelStartArea.RunScript();

            EventBus.OnEvent<PlayerTouchedLevelEndEvent>(EndStrategy);
        }

        void IUpdateable.Update(float elapsedSeconds)
        {
            _progressStrategy.OnUpdate(elapsedSeconds);
        }

        private void EndStrategy(object eventArgs)
        {
            EventBus.Unsubscribe(EndStrategy);
            _ticker.RemoveFixedUpdate(this);

            _progressStrategy.OnEnd();
            OnComplete?.Invoke();

            _levelEndArea.OnComplete += EndLevel;
            _levelEndArea.RunScript();
        }

        private void EndLevel()
        {
            _ticker.SetIsPaused(true);

            ServiceLocator.Get<GuiServiceProxy>()
                .TryShow<LevelCompletionModalController>();
        }
    }
}
