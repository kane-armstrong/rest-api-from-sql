using Armsoft.RestApiFromSqlSchema.Components.Solution.Global.Enumerations;

namespace Armsoft.RestApiFromSqlSchema.Components.Solution.Global
{
    public abstract class ProjectConfigurationId
    {
        public ProjectConfigurationCode Code { get; }

        protected ProjectConfigurationId(ProjectConfigurationCode code)
        {
            Code = code;
        }
    }
}