using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gooey;
using UnityEditor;

namespace Source.Editor.CodeGeneration.Generators
{
    public class ControllerFactoryCodeGen : CodeGenerator
    {
        private const string USINGS = "%USINGS%";
        private const string CONTENT = "%CONTENT%";

        private const string ViewSuffix = "View";
        private const string ControllerSuffix = "Controller";

        private const string TemplateName = "ControllerFactory";
        private static readonly string FilePath = $"{SourceRoot}Game{DirSep}Services{DirSep}Gooey{DirSep}Controllers{DirSep}ControllerFactory.cs";

        [MenuItem(CodeGenConstants.CodeGenMenu + "Controller Factory")]
        public static void Generate()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(e => e.GetTypes())
                .Where(e => !string.IsNullOrWhiteSpace(e.Namespace) &&
                            e.Namespace.StartsWith("Game"))
                .ToArray();

            var viewTypes = types
                .Where(e => e.Name.EndsWith(ViewSuffix) &&
                            e.Name != ViewSuffix)
                .ToArray();

            var controllerTypes = types
                .Where(e => e.Name.EndsWith(ControllerSuffix) &&
                            e.GetInterfaces().Contains(typeof(IGui)))
                .ToArray();

            var usingNamespaces = new List<string>();
            var sbContent = new StringBuilder();
            foreach (var viewType in viewTypes)
            {
                var controllerType = GetControllerType(viewType, controllerTypes);
                if (controllerType == null)
                {
                    continue;
                }

                usingNamespaces.Add(CreateUsingStatement(controllerType));
                sbContent.AppendLine(CreateSwitchCase(viewType, controllerType));
            }

            var sbUsings = new StringBuilder();
            usingNamespaces.Distinct()
                .ToList()
                .ForEach(e => sbUsings.AppendLine(e));

            var template = LoadTemplate(TemplateName)
                .Replace(USINGS, sbUsings.ToString())
                .Replace(CONTENT, sbContent.ToString());

            WriteAndRefresh(FilePath, template);
        }

        private static Type GetControllerType(Type viewType, Type[] controllerTypes)
        {
            var viewName = viewType.Name.Replace(ViewSuffix, string.Empty);

            return controllerTypes
                .FirstOrDefault(e => e.Name.StartsWith(viewName));
        }

        private static string CreateSwitchCase(Type viewType, Type controllerType)
        {
            return new StringBuilder()
                .AppendLine($"                case \"{viewType.Name}\":")
                .AppendLine($"                    return new {controllerType.Name}(({viewType.Name})view);")
                .ToString();
        }

        private static string CreateUsingStatement(Type controllerType)
        {
            return $"using {controllerType.Namespace};";
        }
    }
}
