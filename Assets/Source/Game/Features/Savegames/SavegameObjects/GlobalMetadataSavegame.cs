using System;
using UnityEngine;

namespace Game.Features.Savegames.SavegameObjects
{
    [Serializable]
    public class GlobalMetadataSavegame : MetadataSavegame
    {
        public string ClientVersion;
        public RuntimePlatform Platform;
    }
}
