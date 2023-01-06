namespace Savegames.Middleware
{
    public interface IMiddlewareProcessor
    {
        void RunMiddleware<T>(T savegame, ObjectMiddlewareStage stage);
        string RunMiddleware(string serialized, SerializedMiddlewareStage stage);
    }
}