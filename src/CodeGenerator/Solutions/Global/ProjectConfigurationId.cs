using CodeGenerator.Solutions.Global.Enumerations;

namespace CodeGenerator.Solutions.Global;

public abstract class ProjectConfigurationId
{
    public ProjectConfigurationCode Code { get; }

    protected ProjectConfigurationId(ProjectConfigurationCode code)
    {
        Code = code;
    }
}