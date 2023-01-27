using EntiCS.Ticking;
using Game.Features.EntiCS;
using Game.Features.GameWorld.Levels.ProgressStrategies;
using Game.Static.Locators;
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

        public override void OnStart()
        {
            _progressStrategy.OnStart();

            FeatureLocator.Get<Entics>().Ticker
                .AddFixedUpdate(this);
        }

        public override void OnEnd()
        {
            FeatureLocator.Get<Entics>().Ticker
                .RemoveFixedUpdate(this);

            _progressStrategy.OnEnd();
        }

        void IUpdateable.Update(float elapsedSeconds)
        {
            _progressStrategy.OnUpdate(elapsedSeconds);
        }
    }
}
