using Savegames.Utility;
using System;
using System.IO;

namespace Savegames.IO
{
    public class FileStorageIO : IStorageIO
    {
        private readonly string _rootPath;

        public FileStorageIO(string rootPath)
        {
            _rootPath = rootPath;
        }

        public bool Exists(string fileName)
        {
            try
            {
                if (!Directory.Exists(_rootPath))
                {
                    return false;
                }

                var path = GetPath(fileName);
                return File.Exists(path);
            }
            catch (Exception e)
            {
                SavegameLog.Error("Failed to CHECK savegame", e);
                return false;
            }
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
                if (!Directory.Exists(_rootPath))
                {
                    Directory.CreateDirectory(_rootPath);
                }

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
            return Path.Combine(_rootPath, fileName);
        }
    }
}
