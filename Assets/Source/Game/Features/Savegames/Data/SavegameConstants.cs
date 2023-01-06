using UnityEngine;

namespace Game.Features.Savegames.Data
{
    public static class SavegameConstants
    {
        public static string RootPath => Application.isEditor ? "Savegame" : Application.persistentDataPath;
        public static string GlobalSaveFileName => "global.sav";
    }
}
