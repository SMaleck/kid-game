using Game.Features.GameWorld.Levels.ProgressStrategies;
using Game.Static.Locators;
using System;
using UnityEngine;

namespace Game.Features.GameWorld.Levels
{
    public class LevelStateStrategy : MonoFeature
    {
        [field: SerializeField] public LevelProgressStrategy ProgressStrategy { get; private set; }
        [field: SerializeField] public LevelStartArea LevelStartArea { get; private set; }
        [field: SerializeField] public LevelEndArea LevelEndArea { get; private set; }

        public float MinProgress => ProgressStrategy.MinProgress;
        public float MaxProgress => ProgressStrategy.MaxProgress;
        public float Progress => ProgressStrategy.Progress;
        public float RelativeProgress => ProgressStrategy.RelativeProgress;
        public bool IsComplete => ProgressStrategy.IsComplete;
        public LevelState State { get; private set; }

        public Action OnComplete { get; set; }

        public override void OnStart()
        {
            FeatureLocator.Get<LevelStateFeature>().StartStrategy(this);
        }
    }
}
