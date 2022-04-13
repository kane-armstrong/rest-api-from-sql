using System;
using CodeGenerator.Solutions.Global.Enumerations;

namespace CodeGenerator.Solutions.Global;

public class PlatformConfiguration
{
    public BuildConfiguration BuildConfiguration { get; }
    public CpuConfiguration CpuConfiguration { get; }
    public ProjectConfigurationCode Code { get; }
    public Guid ProjectSectionId { get; }

    public PlatformConfiguration(BuildConfiguration buildConfiguration, CpuConfiguration cpuConfiguration, Guid projectSectionId, ProjectConfigurationCode code)
    {
        BuildConfiguration = buildConfiguration;
        CpuConfiguration = cpuConfiguration;
        ProjectSectionId = projectSectionId;
        Code = code;
    }
}