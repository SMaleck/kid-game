using UnityEngine;

namespace Game.Features.Savegames.Data
{
    public static class SavegameConstants
    {
        public static string RootPath => Application.isEditor ? "Savegame" : Application.persistentDataPath;
        public static string SaveFileExtension => ".sav";
        public static string GlobalSaveFileName => "global" + SaveFileExtension;

        public static int DefaultMiddlewareOrder => 0;
        public static int Version => 1;
    }
}
