namespace Savegames.Settings
{
    public interface ISavegameSettings
    {
        string RootPath { get; }
        string DefaultFileName { get; }
        string DefaultFilePath { get; }
    }
}