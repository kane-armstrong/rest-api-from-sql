using System.Reflection;
using Pedantic.IO;

namespace CodeGenerator.Solutions.Templates.Resources
{
    internal static class TemplateContent
    {
        private static Assembly Assembly => typeof(TemplateContent).Assembly;
        private static string Namespace => typeof(TemplateContent).Namespace;

        public static string Solution => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.Solution.txt");
        public static string ProjectSection => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.ProjectSection.txt");
    }
}