using Game.Data.Tables;
using System;
using System.Linq;
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

        private const int MaxLength = 100;

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
                var sanitizedEnglish = SanitizeForCode(row.English);
                sb.AppendLine($"        /// <summary>");
                sb.AppendLine($"        /// {sanitizedEnglish}");
                sb.AppendLine($"        /// </summary>");
                sb.AppendLine($"        [Text(\"{sanitizedEnglish}\")]");
                sb.AppendLine($"        {row.Key},");
                sb.AppendLine();
            }

            var template = LoadTemplate(TemplateName)
                .Replace(CONTENT, sb.ToString());

            WriteAndRefresh(FilePath, template);
        }

        private static string SanitizeForCode(string text)
        {
            var cleaned = text
                .Trim()
                .Replace("\"", string.Empty)
                .Replace("\n", string.Empty)
                .Replace("\r", string.Empty);

            var substringLength = Math.Min(cleaned.Length, 100);
            return cleaned.Substring(0, substringLength);
        }
    }
}
