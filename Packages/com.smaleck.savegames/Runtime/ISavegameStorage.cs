using System;

namespace Savegames
{
    public interface ISavegameStorage<TSavegame> where TSavegame : class
    {
        TSavegame Savegame { get; }

        void Initialize(Func<TSavegame> savegameFactoryFunc);
        void Save();
        void Load();
    }
}