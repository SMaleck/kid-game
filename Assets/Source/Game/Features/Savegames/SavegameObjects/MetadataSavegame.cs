using System;

namespace Game.Features.Savegames.SavegameObjects
{
    [Serializable]
    public class MetadataSavegame
    {
        public string Id;
        public DateTime CreatedAtUtc;
        public DateTime UpdatedAtUtc;
    }
}
