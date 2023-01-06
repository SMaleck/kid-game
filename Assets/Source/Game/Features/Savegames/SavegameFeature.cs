using Game.Features.Player.Creation;
using Game.Features.Player.Savegames;
using Game.Features.Savegames.Data;
using Savegames;
using Savegames.IO;
using Savegames.Middleware;
using Savegames.Serialization;
using System;

namespace Game.Features.Savegames
{
    public class SavegameFeature : Feature
    {
        private readonly IStorageIO _storageIO;
        private readonly ISerializer _serializer;
        private readonly IMiddlewareProcessor _middleware;

        public ISavegameStorage<GlobalSavegame> GlobalSavegameStorage;

        public SavegameFeature()
        {
            _storageIO = new FileStorageIO(SavegameConstants.RootPath);
            _serializer = new JsonSerializer();
            _middleware = new MiddlewareProcessor(
                Array.Empty<ISavegameObjectMiddleware>(),
                Array.Empty<ISavegameSerializedMiddleware>());

            GlobalSavegameStorage = new SavegameStorage<GlobalSavegame>(
                _storageIO,
                _serializer,
                SavegameConstants.GlobalSaveFileName,
                _middleware);

            GlobalSavegameStorage.Initialize(SavegameFactory.CreateGlobalSavegame);
        }
    }
}
