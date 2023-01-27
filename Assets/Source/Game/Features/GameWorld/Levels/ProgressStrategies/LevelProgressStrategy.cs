using Game.Features.GameWorld.Player;
using Game.Static.Locators;
using Game.Utility.Extensions;
using UnityEngine;

namespace Game.Features.GameWorld.Levels.ProgressStrategies
{
    public class LevelProgressStrategy : ScriptableObject, ILevelProgressStrategy
    {
        [field: SerializeField] public float MinProgress { get; private set; }
        [field: SerializeField] public float MaxProgress { get; private set; }
        [HideInInspector] public float Progress { get; protected set; }
        [HideInInspector] public float RelativeProgress { get; protected set; }
        [HideInInspector] public bool IsComplete { get; protected set; }

        protected PlayerEntityFeature PlayerEntity;

        public void OnStart()
        {
            PlayerEntity = FeatureLocator.Get<PlayerEntityFeature>();
            OnStartInternal();
        }

        public void OnEnd()
        {
            OnEndInternal();
        }

        public void OnUpdate(float elapsedSeconds)
        {
            OnUpdateInternal(elapsedSeconds);
            UpdateRelativeProgress();
        }

        protected virtual void OnStartInternal()
        {
        }

        protected virtual void OnEndInternal()
        {
        }

        protected virtual void OnUpdateInternal(float elapsedSeconds)
        {
        }

        private void UpdateRelativeProgress()
        {
            RelativeProgress = (Progress / MaxProgress).Clamp(0, 1);
            IsComplete = RelativeProgress >= 1f;
        }
    }
}
