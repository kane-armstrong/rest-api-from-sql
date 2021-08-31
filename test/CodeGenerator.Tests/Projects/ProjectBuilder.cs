using CodeGenerator.Projects;

namespace CodeGenerator.Tests.Projects
{
    public class ProjectBuilder
    {
        private string _name;
        private string _targetFramework;
        private string _path;

        public ProjectBuilder WithName(string value)
        {
            _name = value;
            return this;
        }

        public ProjectBuilder WithTargetFramework(string value)
        {
            _targetFramework = value;
            return this;
        }

        public ProjectBuilder WithPath(string value)
        {
            _path = value;
            return this;
        }

        public Project Build()
        {
            return new Project(_name ?? "MyProject", _targetFramework ?? "net5.0");
        }
    }
}
