using System;

namespace Game.Features.Savegames.SavegameObjects
{
    [Serializable]
    public class PlayerMetadataSavegame : MetadataSavegame
    {
        public string PlayerName;
        public string SaveFileName;
        public long TotalPlayTimeTicks;
    }
}
