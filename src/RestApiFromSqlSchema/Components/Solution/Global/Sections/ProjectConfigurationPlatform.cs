using System;
using RestApiFromSqlSchema.Components.Solution.Global.Enumerations;

namespace RestApiFromSqlSchema.Components.Solution.Global.Sections;

public class ProjectConfigurationPlatform
{
    internal const string GlobalSectionId = "ProjectConfigurationPlatforms";
    internal static readonly GlobalSectionType GlobalSectionType = GlobalSectionType.postSolution;

    public BuildConfiguration BuildConfiguration { get; }
    public CpuConfiguration CpuConfiguration { get; }
    public ProjectConfigurationId ProjectConfigurationId { get; }
    public Guid ProjectSectionId { get; }

    public ProjectConfigurationPlatform(Guid projectSectionId, BuildConfiguration buildConfiguration, CpuConfiguration cpuConfiguration, ProjectConfigurationId projectConfigurationId)
    {
        ProjectSectionId = projectSectionId;
        BuildConfiguration = buildConfiguration;
        CpuConfiguration = cpuConfiguration;
        ProjectConfigurationId = projectConfigurationId;
    }

    private const string ProjectConfigurationPlatformTemplate = "{{{0}}}.{1}|{2}.{3} = {1}|{2}";

    public override string ToString()
    {
        return string.Format(ProjectConfigurationPlatformTemplate, ProjectSectionId.ToString().ToUpper(), BuildConfiguration, CpuConfiguration.ToString().Replace("_", " "), ProjectConfigurationId);
    }
}