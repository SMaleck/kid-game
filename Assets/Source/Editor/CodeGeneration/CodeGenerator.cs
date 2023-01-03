using System.IO;
using UnityEditor;
using UnityEngine;

namespace Source.Editor.CodeGeneration
{
    public abstract class CodeGenerator : EditorWindow
    {
        public static char DirSep => Path.DirectorySeparatorChar;
        public const string TemplateFileExt = ".cs.txt";

        public static readonly string SourceRoot = $"{Application.dataPath}{DirSep}Source{DirSep}";
        public static readonly string TemplateRoot = $"{SourceRoot}Editor{DirSep}CodeGeneration{DirSep}Templates{DirSep}";

        protected static string LoadTemplate(string templateName)
        {
            var templatePath = $"{TemplateRoot}{DirSep}{templateName}{TemplateFileExt}";
            var templateText = File.ReadAllText(templatePath);

            return templateText.Replace(CodeGenConstants.CODEGEN_WARNING, CodeGenConstants.CodeGenWarning);
        }

        protected static void WriteAndRefresh(string filePath, string content)
        {
            File.WriteAllText(filePath, content);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        protected static void Log(string message)
        {
            Debug.Log($"[CodeGen] {message}");
        }

        protected static void LogError(string message)
        {
            Debug.LogError($"[CodeGen] {message}");
        }
    }
}
