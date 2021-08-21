using System.Reflection;
using Pedantic.IO;

namespace CodeGenerator.Templates.Resources
{
    internal static class TemplateContent
    {
        private static Assembly Assembly => typeof(TemplateContent).Assembly;
        private static string Namespace => typeof(TemplateContent).Namespace;

        internal static string Class => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.Class.txt");
        internal static string Method => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.Method.txt");
    }
}