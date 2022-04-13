using CodeGenerator.Solutions.Global.Enumerations;

namespace CodeGenerator.Solutions.Global;

public class ActiveConfigurationId : ProjectConfigurationId
{
    public ActiveConfigurationId() : base(ProjectConfigurationCode.ActiveCfg)
    {
    }

    public override string ToString()
    {
        return Code.ToString();
    }
}