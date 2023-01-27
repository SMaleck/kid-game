using Game.Utility;
using UnityEngine;

namespace Game.Features.GameWorld.Levels.ProgressStrategies
{
    [CreateAssetMenu(menuName = ProjectConst.MenuLevel + nameof(DistanceLevelProgressStrategy), fileName = nameof(DistanceLevelProgressStrategy))]
    public class DistanceLevelProgressStrategy : LevelProgressStrategy
    {
        protected override void OnUpdateInternal(float elapsedSeconds)
        {
            Progress = PlayerEntity.RunStats.ElapsedDistanceUnits;
        }
    }
}
