using System;
using System.Collections.Generic;

namespace Game.Features.Player.Savegames
{
    [Serializable]
    public class GlobalSavegame
    {
        public MetadataSavegame MetadataSavegame;
        public List<PlayerSavegame> PlayerSavegames;
    }
}
