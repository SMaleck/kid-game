using System.IO;
using UnityEngine;

namespace Savegames.Settings
{
    public class SavegameSettings : ISavegameSettings
    {
        public string RootPath => Application.isEditor ? "Savegame" : Application.persistentDataPath;
        public string DefaultFileName => "savegame.sav";
        public string DefaultFilePath => Path.Combine(RootPath, DefaultFileName);
    }
}
