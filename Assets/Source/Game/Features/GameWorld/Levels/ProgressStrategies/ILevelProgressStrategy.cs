namespace Game.Features.GameWorld.Levels.ProgressStrategies
{
    public interface ILevelProgressStrategy
    {
        float MinProgress { get; }
        float MaxProgress { get; }
        float Progress { get; }
        float RelativeProgress { get; }

        void OnUpdate(float elapsedSeconds);
    }
}
