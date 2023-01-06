namespace Savegames.Middleware
{
    public interface ISavegameMiddleware
    {
        int Order { get; }
    }
}
