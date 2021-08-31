using System.Reflection;
using Pedantic.IO;

namespace CodeGenerator.Projects.Templates.Resources
{
    internal static class TemplateContent
    {
        private static Assembly Assembly => typeof(TemplateContent).Assembly;
        private static string Namespace => typeof(TemplateContent).Namespace;

        public static string Project => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.Project.txt");
    }
}