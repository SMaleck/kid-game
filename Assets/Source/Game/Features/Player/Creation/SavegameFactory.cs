using Game.Features.Player.Savegames;
using Game.Services.Time;
using Game.Static.Locators;
using System;
using System.Collections.Generic;

namespace Game.Features.Player.Creation
{
    public static class SavegameFactory
    {
        public static GlobalSavegame CreateGlobalSavegame()
        {
            return new GlobalSavegame()
            {
                MetadataSavegame = CreateMetadataSavegame(),
                PlayerSavegames = new List<PlayerSavegame>()
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

        public static PlayerSavegame CreatePlayerSavegame(string playerName)
        {
            var id = Guid.NewGuid().ToString();
            var now = ServiceLocator.Get<TimeService>().NowUtc;

            return new PlayerSavegame()
            {
                Id = id,
                CreatedAtUtc = now,
                PlayerName = playerName,
                SaveFileName = $"{playerName}_{id}"
            };
        }

        public static PlayerStateSavegame CreatePlayerStateSavegame()
        {
            return new PlayerStateSavegame();
        }
    }
}
