using Game.Editor.Data.Importers;
using Game.Utility;
using Source.Editor.CodeGeneration.Generators;
using UnityEditor;

namespace Source.Editor.Tools
{
    public class LocaImporter : EditorWindow
    {
        [MenuItem(ProjectConst.MenuRoot + "Import Loca")]
        public static void ImportLoca()
        {
            LocalizationWorkbookImporter.Import();
            TextKeysCodeGen.Generate();
        }
    }
}
