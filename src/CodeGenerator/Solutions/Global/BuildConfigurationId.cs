using CodeGenerator.Solutions.Global.Enumerations;

namespace CodeGenerator.Solutions.Global
{
    public class BuildConfigurationId : ProjectConfigurationId
    {
        public int Id { get; }

        public BuildConfigurationId(int id) : base(ProjectConfigurationCode.Build)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"{Code}.{Id}";
        }
    }
}