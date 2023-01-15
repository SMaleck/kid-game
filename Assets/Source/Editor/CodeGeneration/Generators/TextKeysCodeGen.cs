using System.Linq;
using Game.Data.Tables;
using System.Text;
using UnityEditor;

namespace Source.Editor.CodeGeneration.Generators
{
    public class TextKeysCodeGen : CodeGenerator
    {
        private static readonly string CONTENT = "%CONTENT%";
        private static readonly string TemplateName = "TextKeys";
        private static readonly string FilePath = $"{SourceRoot}Game{DirSep}Services{DirSep}Text{DirSep}TextKeys.cs";
        private static readonly string LocalizationAssetPath = @"Assets/Game/Data/Imports/Localization.asset";

        [MenuItem(CodeGenConstants.CodeGenMenu + "TextKeys")]
        public static void Generate()
        {
            var locaTableRows = AssetDatabase.LoadAssetAtPath<LocalizationTable>(LocalizationAssetPath).Rows
                .OrderBy(e => e.Key)
                .ToArray();

            var sb = new StringBuilder();
            for (var i = 0; i < locaTableRows.Length; i++)
            {
                var row = locaTableRows[i];
                sb.AppendLine($"        /// <summary>");
                sb.AppendLine($"        /// {row.English}");
                sb.AppendLine($"        /// </summary>");
                sb.AppendLine($"        [Text(\"{row.English}\")]");
                sb.AppendLine($"        {row.Key},");
                sb.AppendLine();
            }

            var template = LoadTemplate(TemplateName)
                .Replace(CONTENT, sb.ToString());

            WriteAndRefresh(FilePath, template);
        }
    }
}
