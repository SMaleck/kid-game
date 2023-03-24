using System;
using System.Collections.Generic;

namespace Game.Features.Savegames.SavegameObjects
{
    [Serializable]
    public class GlobalSavegame
    {
        public GlobalMetadataSavegame MetadataSavegame;
        
        public string LastPlayerId;
        public List<PlayerMetadataSavegame> PlayerSavegames;
    }
}
