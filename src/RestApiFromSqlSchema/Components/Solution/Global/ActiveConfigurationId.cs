using Armsoft.RestApiFromSqlSchema.Components.Solution.Global.Enumerations;

namespace Armsoft.RestApiFromSqlSchema.Components.Solution.Global
{
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
}