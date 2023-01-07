using Game.Features.Savegames.SavegameObjects;
using Game.Services.ClientInfo;
using Game.Services.Time;
using Game.Static.Locators;
using System;
using System.Collections.Generic;

namespace Game.Features.Savegames.Creation
{
    public static class SavegameFactory
    {
        public static GlobalSavegame CreateGlobalSavegame()
        {
            return new GlobalSavegame()
            {
                MetadataSavegame = CreateGlobalMetadataSavegame(),
                PlayerSavegames = new List<PlayerMetadataSavegame>()
            };
        }

        public static MetadataSavegame CreateMetadataSavegame()
        {
            var id = Guid.NewGuid().ToString();
            var now = ServiceLocator.Get<TimeService>().NowUtc;

            return new MetadataSavegame()
            {
                Id = id,
                CreatedAtUtc = now,
                UpdatedAtUtc = now,
            };
        }

        public static GlobalMetadataSavegame CreateGlobalMetadataSavegame()
        {
            var id = Guid.NewGuid().ToString();
            var now = ServiceLocator.Get<TimeService>().NowUtc;

            var clientInfo = ServiceLocator.Get<ClientInfoService>();

            return new GlobalMetadataSavegame()
            {
                Id = id,
                CreatedAtUtc = now,
                UpdatedAtUtc = now,
                ClientVersion = clientInfo.Version,
                Platform = clientInfo.Platform,
            };
        }

        public static PlayerMetadataSavegame CreatePlayerMetadataSavegame(string playerName)
        {
            var id = Guid.NewGuid().ToString();
            var now = ServiceLocator.Get<TimeService>().NowUtc;

            return new PlayerMetadataSavegame()
            {
                Id = id,
                CreatedAtUtc = now,
                UpdatedAtUtc = now,
                PlayerName = playerName,
                SaveFileName = $"{playerName}_{id}",
                TotalPlayTimeTicks = 0L
            };
        }

        public static PlayerStateSavegame CreatePlayerStateSavegame(PlayerMetadataSavegame metadata)
        {
            return new PlayerStateSavegame()
            {
                MetadataSavegame = metadata
            };
        }
    }
}
