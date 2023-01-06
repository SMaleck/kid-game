namespace Savegames.Middleware
{
    public interface ISavegameObjectMiddleware : ISavegameMiddleware
    {
        ObjectMiddlewareStage Stage { get; }

        void Process<T>(T savegame);
    }
}
