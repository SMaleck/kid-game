using System;
using Savegames.IO;
using Savegames.Middleware;
using Savegames.Serialization;
using Savegames.Utility;

namespace Savegames
{
    public class SavegameStorage<TSavegame> : ISavegameStorage<TSavegame> where TSavegame : class
    {
        private readonly IStorageIO _storageIO;
        private readonly ISerializer _serializer;
        private readonly string _fileName;
        private readonly IMiddlewareProcessor _middleware;

        public TSavegame Savegame { get; private set; }

        public SavegameStorage(
            IStorageIO storageIO,
            ISerializer serializer,
            string fileName,
            IMiddlewareProcessor middleware)
        {
            _storageIO = storageIO;
            _serializer = serializer;
            _fileName = fileName;
            _middleware = middleware;
        }

        public void Initialize(Func<TSavegame> savegameFactoryFunc)
        {
            if (_storageIO.Exists(_fileName))
            {
                Load();
                return;
            }

            Savegame = savegameFactoryFunc.Invoke();
            Save();
        }

        public void Save()
        {
            try
            {
                _middleware.RunMiddleware(Savegame, ObjectMiddlewareStage.OnSave_BeforeSerialization);
                var serialized = _serializer.Serialize(Savegame);
                _middleware.RunMiddleware(serialized, SerializedMiddlewareStage.OnSave_AfterSerialization);
                _storageIO.Write(_fileName, serialized);
            }
            catch (Exception e)
            {
                SavegameLog.Error($"Cannot SAVE savegame [{_fileName}]", e);
            }
        }

        public void Load()
        {
            try
            {
                var serialized = _storageIO.Read(_fileName);
                _middleware.RunMiddleware(serialized, SerializedMiddlewareStage.OnLoad_BeforeDeserialization);
                Savegame = _serializer.Deserialize<TSavegame>(serialized);
                _middleware.RunMiddleware(Savegame, ObjectMiddlewareStage.OnLoad_AfterDeserialization);
            }
            catch (Exception e)
            {
                SavegameLog.Error($"Cannot LOAD savegame [{_fileName}]", e);
            }
        }
    }
}
