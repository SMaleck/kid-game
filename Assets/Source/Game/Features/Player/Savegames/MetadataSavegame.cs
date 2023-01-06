using System;

namespace Game.Features.Player.Savegames
{
    [Serializable]
    public class MetadataSavegame
    {
        public string Id;
        public DateTime CreatedAtUtc;
        public DateTime UpdatedAtUtc;
    }
}
