using Game.Static.Locators;
using System;
using System.Linq;
using System.Text;
using UnityEditor;

namespace Source.Editor.CodeGeneration.Generators
{
    public class LocatorConstCodeGen : CodeGenerator
    {
        private static readonly string CONTENT = "%CONTENT%";
        private static readonly string TemplateName = "LocatorConst";
        private static readonly string FilePath = $"{SourceRoot}Game{DirSep}Utility{DirSep}LocatorConst.cs";

        private const string Line = "        public const int {0} = {1};";
        private const string NameDataCount = "DataCount";
        private const string NameServiceCount = "ServiceCount";
        private const string NameFeatureCount = "FeatureCount";

        [MenuItem(CodeGenConstants.CodeGenMenu + "LocatorConst")]
        public static void Generate()
        {
            var allTypes = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(e => e.GetTypes())
                .ToArray();

            // ToDo LocatorConstCodeGen includes base classes, which are not being instantiated.
            // This creates a very little overhead, so acceptable in this project, but could be optimized.
            var dataCount = GetTypeCount(allTypes, typeof(IData));
            var serviceCount = GetTypeCount(allTypes, typeof(IService));
            var featureCount = GetTypeCount(allTypes, typeof(IFeature));

            var content = new StringBuilder()
                .AppendLine(GetContentLine(NameDataCount, dataCount))
                .AppendLine(GetContentLine(NameServiceCount, serviceCount))
                .AppendLine(GetContentLine(NameFeatureCount, featureCount))
                .ToString();

            var template = LoadTemplate(TemplateName)
                .Replace(CONTENT, content);

            WriteAndRefresh(FilePath, template);
        }

        private static int GetTypeCount(Type[] types, Type checkType)
        {
            return types
                .Count(e => e.GetInterfaces().Any(i => i == checkType));
        }

        private static string GetContentLine(string name, int count)
        {
            return string.Format(Line, name, count);
        }
    }
}
