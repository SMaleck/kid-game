using System;
using System.IO;
using Savegames.Settings;
using Savegames.Utility;

namespace Savegames.IO
{
    public class FileStorageIO : IStorageIO
    {
        private readonly SavegameSettings _settings;

        public FileStorageIO(SavegameSettings settings)
        {
            _settings = settings;
        }

        public string Read(string fileName)
        {
            try
            {
                var path = GetPath(fileName);
                return File.ReadAllText(path);
            }
            catch (Exception e)
            {
                SavegameLog.Error("Failed to READ savegame", e);
                return string.Empty;
            }
        }

        public void Write(string fileName, string serialized)
        {
            try
            {
                var path = GetPath(fileName);
                File.WriteAllText(path, serialized);
            }
            catch (Exception e)
            {
                SavegameLog.Error("Failed to READ savegame", e);
            }
        }

        private string GetPath(string fileName)
        {
            return Path.Combine(_settings.RootPath, fileName);
        }
    }
}
