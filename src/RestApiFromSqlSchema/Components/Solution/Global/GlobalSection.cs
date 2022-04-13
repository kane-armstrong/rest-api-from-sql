using System.Collections.Generic;
using System.Text;
using RestApiFromSqlSchema.Components.Solution.Global.Sections;

namespace RestApiFromSqlSchema.Components.Solution.Global;

public class GlobalSection
{
    public IEnumerable<SolutionConfigurationPlatform> SolutionConfigurationPlatforms { get; }
    public IEnumerable<ProjectConfigurationPlatform> ProjectConfigurationPlatforms { get; }
    public SolutionProperties SolutionProperties { get; }
    public ExtensibilityGlobals ExtensibilityGlobals { get; }

    private const string GlobalStartToken = "Global";
    private const string GlobalEndToken = "EndGlobal";
    private const string GlobalSectionStartToken = "GlobalSection";
    private const string GlobalSectionEndToken = "EndGlobalSection";

    public GlobalSection(
        IEnumerable<SolutionConfigurationPlatform> solutionConfigurationPlatforms,
        IEnumerable<ProjectConfigurationPlatform> projectConfigurationPlatforms,
        SolutionProperties solutionProperties,
        ExtensibilityGlobals extensibilityGlobals)
    {
        SolutionConfigurationPlatforms = solutionConfigurationPlatforms;
        ProjectConfigurationPlatforms = projectConfigurationPlatforms;
        SolutionProperties = solutionProperties;
        ExtensibilityGlobals = extensibilityGlobals;
    }

    private const string Tab = "\t";

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(GlobalStartToken);
        StringifySolutionConfigurationPlatforms(sb);
        StringifyProjectConfigurationPlatforms(sb);
        StringifySolutionPropertiesSection(sb);
        StringifyExtensibilityGlobalsSection(sb);
        sb.AppendLine(GlobalEndToken);
        return sb.ToString();
    }

    private void StringifySolutionConfigurationPlatforms(StringBuilder sb)
    {
        sb.AppendLine($"{Tab}{GlobalSectionStartToken}({SolutionConfigurationPlatform.GlobalSectionId}) = {SolutionConfigurationPlatform.GlobalSectionType.ToString()}");
        foreach (var cfg in SolutionConfigurationPlatforms)
        {
            sb.AppendLine($"{Tab}{Tab}{cfg}");
        }
        sb.AppendLine($"{Tab}{GlobalSectionEndToken}");
    }

    private void StringifyProjectConfigurationPlatforms(StringBuilder sb)
    {
        sb.AppendLine($"{Tab}{GlobalSectionStartToken}({ProjectConfigurationPlatform.GlobalSectionId}) = {ProjectConfigurationPlatform.GlobalSectionType.ToString()}");
        foreach (var cfg in ProjectConfigurationPlatforms)
        {
            sb.AppendLine($"{Tab}{Tab}{cfg}");
        }
        sb.AppendLine($"{Tab}{GlobalSectionEndToken}");
    }

    private void StringifySolutionPropertiesSection(StringBuilder sb)
    {
        sb.AppendLine($"{Tab}{GlobalSectionStartToken}({SolutionProperties.GlobalSectionId}) = {SolutionProperties.GlobalSectionType.ToString()}");
        sb.AppendLine($"{Tab}{Tab}{SolutionProperties}");
        sb.AppendLine($"{Tab}{GlobalSectionEndToken}");
    }

    private void StringifyExtensibilityGlobalsSection(StringBuilder sb)
    {
        sb.AppendLine($"{Tab}{GlobalSectionStartToken}({ExtensibilityGlobals.GlobalSectionId}) = {ExtensibilityGlobals.GlobalSectionType.ToString()}");
        sb.AppendLine($"{Tab}{Tab}{ExtensibilityGlobals}");
        sb.AppendLine($"{Tab}{GlobalSectionEndToken}");
    }
}