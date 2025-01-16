using EntiCS.Ticking;
using Game.Features.Ticking;
using Game.Features.UI.Completion;
using Game.Services.Gooey;
using Game.Static.Events;
using Game.Static.Events.Dtos;
using Game.Static.Locators;
using System;

namespace Game.Features.GameWorld.Levels
{
    // ToDo Currently ProgressStrategies serve no purpose anymore. Can probably be removed, if no procedural level is being added
    public class LevelStateFeature : MonoFeature, IUpdateable
    {
        private LevelStateStrategy _strategy;
        private ITicker _ticker;

        public float MinProgress => _strategy?.ProgressStrategy.MinProgress ?? 0;
        public float MaxProgress => _strategy?.ProgressStrategy.MaxProgress ?? 0;
        public float Progress => _strategy?.ProgressStrategy.Progress ?? 0;
        public float RelativeProgress => _strategy?.ProgressStrategy.RelativeProgress ?? 0;
        public bool IsComplete => _strategy?.ProgressStrategy.IsComplete ?? false;
        public LevelState State { get; private set; }

        public Action OnComplete { get; set; }

        public void StartStrategy(LevelStateStrategy strategy)
        {
            _strategy = strategy;
            State = LevelState.Intro;

            _ticker = FeatureLocator.Get<TickerFeature>().SceneTicker;
            _ticker.SetIsPaused(false);

            _strategy.LevelStartArea.OnComplete += StartLevel;
            _strategy.LevelStartArea.RunScript();

            EventBus.OnEvent<PlayerTouchedLevelEndEvent>(EndStrategy);
        }

        public override void OnEnd()
        {
            _ticker.Remove(TickType.FixedUpdate, this);
            EventBus.Unsubscribe(EndStrategy);
        }

        void IUpdateable.OnUpdate(float elapsedSeconds)
        {
            _strategy.ProgressStrategy.OnUpdate(elapsedSeconds);
        }

        private void EndStrategy(object eventArgs)
        {
            State = LevelState.Outro;

            EventBus.Unsubscribe(EndStrategy);
            _ticker.Remove(TickType.FixedUpdate, this);

            _strategy.ProgressStrategy.OnEnd();
            OnComplete?.Invoke();

            _strategy.LevelEndArea.OnComplete += EndLevel;
            _strategy.LevelEndArea.RunScript();
        }

        private void StartLevel()
        {
            State = LevelState.Running;

            _strategy.LevelStartArea.OnComplete -= StartLevel;
            _strategy.ProgressStrategy.OnStart();

            _ticker.Add(TickType.FixedUpdate, this);
        }

        private void EndLevel()
        {
            _strategy.LevelEndArea.OnComplete -= EndLevel;

            ServiceLocator.Get<GuiServiceProxy>()
                .TryShow<LevelCompletionModalController>();
        }
    }
}
