using Game.Features.Savegames.Creation;
using Game.Features.Savegames.Data;
using Game.Features.Savegames.Events;
using Game.Features.Savegames.Middleware;
using Game.Features.Savegames.SavegameObjects;
using Game.Static.Events;
using Game.Utility;
using Savegames;
using Savegames.IO;
using Savegames.Middleware;
using Savegames.Serialization;
using System;
using System.Linq;

namespace Game.Features.Savegames
{
    public class SavegameFeature : Feature
    {
        private readonly IStorageIO _storageIO;
        private readonly ISerializer _serializer;

        public ISavegameStorage<GlobalSavegame> GlobalStorage;
        public ISavegameStorage<PlayerStateSavegame> PlayerStorage;

        public SavegameFeature()
        {
            _storageIO = new FileStorageIO(SavegameConstants.RootPath);
            _serializer = new JsonSerializer();

            GlobalStorage = CreateGlobalSavegameStorage();
        }

        public void SaveAll()
        {
            // Update Player MetaData in global savegame first
            var i = GlobalStorage.Savegame.PlayerSavegames
                .IndexOf(PlayerStorage.Savegame.MetadataSavegame);

            if (i >= 0 && i < GlobalStorage.Savegame.PlayerSavegames.Count) 
            {
                GlobalStorage.Savegame.PlayerSavegames[i] = PlayerStorage.Savegame.MetadataSavegame;
            }
            
            GlobalStorage.Save();
            PlayerStorage.Save();
        }

        public bool TryLoadPlayer(string id)
        {
            var playerMetaData = GlobalStorage.Savegame.PlayerSavegames
                .FirstOrDefault(e => e.Id == id);

            if (playerMetaData == null)
            {
                GameLog.Error($"Cannot load PlayerId {id}");
                return false;
            }

            SetPlayerStorage(CreatePlayerStateSavegameStorage(playerMetaData));

            return false;
        }

        public void CreatePlayer(string name)
        {
            var metadata = SavegameFactory.CreatePlayerMetadataSavegame(name);

            GlobalStorage.Savegame.PlayerSavegames.Add(metadata);
            SetPlayerStorage(CreatePlayerStateSavegameStorage(metadata));

            SaveAll();
        }

        private ISavegameStorage<GlobalSavegame> CreateGlobalSavegameStorage()
        {
            var middleware = new MiddlewareProcessor(
                new[] { new GlobalSavegameObjectMiddleware() },
                Array.Empty<ISavegameSerializedMiddleware>());

            var savegameStorage = new SavegameStorage<GlobalSavegame>(
                _storageIO,
                _serializer,
                SavegameConstants.GlobalSaveFileName,
                middleware);

            savegameStorage.Initialize(SavegameFactory.CreateGlobalSavegame);

            return savegameStorage;
        }

        private ISavegameStorage<PlayerStateSavegame> CreatePlayerStateSavegameStorage(
            PlayerMetadataSavegame metadata)
        {
            var middleware = new MiddlewareProcessor(
                new[] { new PlayerStateSavegameObjectMiddleware() },
                Array.Empty<ISavegameSerializedMiddleware>());

            var savegameStorage = new SavegameStorage<PlayerStateSavegame>(
                _storageIO,
                _serializer,
                metadata.SaveFileName,
                middleware);

            savegameStorage.Initialize(() => SavegameFactory.CreatePlayerStateSavegame(metadata));

            return savegameStorage;
        }

        private void SetPlayerStorage(ISavegameStorage<PlayerStateSavegame> storage)
        {
            PlayerStorage = storage;
            EventBus.Publish(new PlayerSavegameLoadedEvent());
        }
    }
}
