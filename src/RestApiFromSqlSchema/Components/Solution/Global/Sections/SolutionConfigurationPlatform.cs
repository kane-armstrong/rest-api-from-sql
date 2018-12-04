using Armsoft.RestApiFromSqlSchema.Components.Solution.Global.Enumerations;

namespace Armsoft.RestApiFromSqlSchema.Components.Solution.Global.Sections
{
    public class SolutionConfigurationPlatform
    {
        internal static string GlobalSectionId = "SolutionConfigurationPlatforms";
        internal static GlobalSectionType GlobalSectionType = GlobalSectionType.preSolution;

        public BuildConfiguration BuildConfiguration { get; }
        public CpuConfiguration CpuConfiguration { get; }

        public SolutionConfigurationPlatform(BuildConfiguration buildConfiguration, CpuConfiguration cpuConfiguration)
        {
            BuildConfiguration = buildConfiguration;
            CpuConfiguration = cpuConfiguration;
        }

        private const string SolutionConfigurationPlatformTemplate = "{0}|{1} = {0}|{1}";

        public override string ToString()
        {
            return string.Format(SolutionConfigurationPlatformTemplate, BuildConfiguration, CpuConfiguration.ToString().Replace("_", " "));
        }
    }
}