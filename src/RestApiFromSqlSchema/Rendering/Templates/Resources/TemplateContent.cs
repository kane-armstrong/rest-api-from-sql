using System.Reflection;
using Pedantic.IO;

namespace Armsoft.RestApiFromSqlSchema.Rendering.Templates.Resources
{
    internal static class TemplateContent
    {
        private static Assembly Assembly => typeof(TemplateContent).Assembly;
        private static string Namespace => typeof(TemplateContent).Namespace;

        internal static string GeneratedCodeDisclaimer => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.GeneratedCodeDisclaimer.txt");
        internal static string ApiController => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.ApiController.txt");
        internal static string ApiActionCreate => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.ApiActionCreate.txt");
        internal static string ApiActionEdit => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.ApiActionEdit.txt");
        internal static string ApiActionDelete => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.ApiActionDelete.txt");
        internal static string ApiActionList => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.ApiActionList.txt");
        internal static string ApiActionGetById => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.ApiActionGetById.txt");
        internal static string ApiActionGetByUniqueKey => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.ApiActionGetByUniqueKey.txt");
        internal static string ApiActionEditByUniqueKey => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.ApiActionEditByUniqueKey.txt");
        internal static string ApiActionDeleteByUniqueKey => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.ApiActionDeleteByUniqueKey.txt");

        internal static string Class => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.Class.txt");

        internal static string DbContext => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.DbContext.txt");
    }
}