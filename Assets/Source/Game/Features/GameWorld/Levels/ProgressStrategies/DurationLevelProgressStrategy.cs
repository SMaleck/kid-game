using Game.Utility;
using UnityEngine;

namespace Game.Features.GameWorld.Levels.ProgressStrategies
{
    [CreateAssetMenu(menuName = ProjectConst.MenuLevel + nameof(DurationLevelProgressStrategy), fileName = nameof(DurationLevelProgressStrategy))]
    public class DurationLevelProgressStrategy : LevelProgressStrategy
    {
        protected override void OnUpdateInternal(float elapsedSeconds)
        {
            Progress = PlayerEntity.RunStats.ElapsedSeconds;
        }
    }
}
