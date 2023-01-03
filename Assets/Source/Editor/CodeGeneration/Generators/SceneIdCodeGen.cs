using System.IO;
using System.Text;
using UnityEditor;

namespace Source.Editor.CodeGeneration.Generators
{
    public class SceneIdCodeGen : CodeGenerator
    {
        private static readonly string CONTENT = "%CONTENT%";
        private static readonly string TemplateName = "SceneId";
        private static readonly string FilePath = $"{SourceRoot}Game{DirSep}Services{DirSep}Scenes{DirSep}SceneId.cs";

        [MenuItem(CodeGenConstants.CodeGenMenu + "SceneId")]
        public static void Generate()
        {
            var sb = new StringBuilder();
            for (var i = 0; i < EditorBuildSettings.scenes.Length; i++)
            {
                var scene = EditorBuildSettings.scenes[i];
                sb.AppendLine(GetContentLine(scene, i));
            }

            var template = LoadTemplate(TemplateName)
                .Replace(CONTENT, sb.ToString());

            WriteAndRefresh(FilePath, template);
        }

        private static string GetContentLine(EditorBuildSettingsScene scene, int i)
        {
            return $"        {GetCleanedName(scene.path)} = {i},";
        }

        private static string GetCleanedName(string scenePath)
        {
            return Path.GetFileNameWithoutExtension(scenePath)
                .Replace("S_", string.Empty);
        }
    }
}
