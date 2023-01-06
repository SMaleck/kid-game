namespace Savegames.Middleware
{
    public interface ISavegameSerializedMiddleware : ISavegameMiddleware
    {
        SerializedMiddlewareStage Stage { get; }

        string Process(string serialized);
    }
}
