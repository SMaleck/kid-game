using System;

namespace Game.Features.Player.Savegames
{
    [Serializable]
    public class PlayerSavegame
    {
        public string Id;
        public DateTime CreatedAtUtc;
        public string PlayerName;
        public string SaveFileName;
        public long TotalPlayTimeTicks;
    }
}
