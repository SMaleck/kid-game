namespace Savegames
{
    public interface ISavegameStorage<TSavegame> where TSavegame : class
    {
        TSavegame Savegame { get; }

        void Initialize(TSavegame savegame = null);
        void Save();
        void Load();
    }
}