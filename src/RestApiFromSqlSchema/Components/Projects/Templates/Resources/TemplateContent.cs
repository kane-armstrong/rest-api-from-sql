using System.Reflection;
using Pedantic.IO;

namespace Armsoft.RestApiFromSqlSchema.Components.Projects.Templates.Resources
{
    internal static class TemplateContent
    {
        private static Assembly Assembly => typeof(TemplateContent).Assembly;
        private static string Namespace => typeof(TemplateContent).Namespace;

        public static string GeneratedCodeDisclaimer => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.GeneratedCodeDisclaimer.txt");
        public static string NetCoreWebApiAppSettings => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.NetCoreWebApiAppSettings.txt");
        public static string NetCoreWebApiCsproj => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.NetCoreWebApiCsproj.txt");
        public static string NetCoreWebApiLaunchSettings => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.NetCoreWebApiLaunchSettings.txt");
        public static string NetCoreWebApiProgram => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.NetCoreWebApiProgram.txt");
        public static string NetCoreWebApiStartup => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.NetCoreWebApiStartup.txt");
        public static string Solution => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.Solution.txt");
        public static string ProjectSection => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.ProjectSection.txt");
    }
}