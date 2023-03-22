using Game.Features.Savegames.Data;
using Game.Utility;
using System.IO;
using UnityEditor;

namespace Source.Editor.Tools
{
    public class SavegameTools : EditorWindow
    {
        private const string MenuRoot = ProjectConst.MenuRoot + "Savegames/";

        [MenuItem(MenuRoot + "Open in Explorer")]
        public static void OpenInExplorer()
        {
            var dir = SavegameConstants.RootPath;
            if (Directory.Exists(dir))
            {
                EditorUtility.RevealInFinder(dir);
            }
        }

        [MenuItem(MenuRoot + "Clear")]
        public static void Clear()
        {
            var dir = SavegameConstants.RootPath;
            if (!Directory.Exists(dir))
            {
                return;
            }

            var files = Directory.GetFiles(dir);
            foreach (var file in files)
            {
                File.Delete(file);
            }
        }
    }
}
