using Antlr4.StringTemplate;
using CodeGenerator.Projects;
using CodeGenerator.Solutions.Global;
using CodeGenerator.Solutions.Global.Enumerations;
using CodeGenerator.Solutions.Global.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeGenerator.Solutions.Templates;
using CodeGenerator.Solutions.Templates.Resources;

namespace CodeGenerator.Solutions
{
    // TODO Remove stuff that is tagged as not making sense - if we need it back we still have SolutionFile
    // TODO Move rendering to a template instead of ToString()ing everything - the latter is inconsistent
    public class Solution
    {
        private const char StartDelimiter = '$';
        private const char EndDelimiter = '$';

        private readonly Guid _solutionGuid;
        private readonly List<ProjectSection> _projects = new();

        private readonly string _solutionDirectory;
        private readonly string _solutionName;

        public Solution(string directory, string name)
        {
            _solutionDirectory = directory;
            _solutionName = name;
            _solutionGuid = Guid.NewGuid();
        }

        public void AddProject(Project project)
        {
            if (_projects.Any(x => x.Project.Name.Equals(project.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new InvalidOperationException($"Failed to add the project as a project with the name '{project.Name}' already exists in the solution.");
            }

            var section = new ProjectSection(project);
            _projects.Add(section);
        }

        public string Render()
        {
            // TODO shift to template

            var projects = new List<string>();
            foreach (var project in _projects)
            {
                projects.Add(project.Render());
            }

            var globalSection = GenerateGlobalSection();
            string globalSectionString = null;
            if (globalSection.ProjectConfigurationPlatforms.Any())
            {
                globalSectionString = globalSection.ToString();
            }
            
            var template = new Template(TemplateContent.Solution, StartDelimiter, EndDelimiter);

            template.Add(SolutionAttributes.ProjectConfigurations, projects);
            template.Add(SolutionAttributes.GlobalSection, globalSectionString);

            return template.Render();
        }

        private GlobalSection GenerateGlobalSection()
        {
            var solutionConfigurationPlatforms = new List<SolutionConfigurationPlatform>
            {
                new SolutionConfigurationPlatform(BuildConfiguration.Debug, CpuConfiguration.Any_CPU),
                new SolutionConfigurationPlatform(BuildConfiguration.Release, CpuConfiguration.Any_CPU),
                new SolutionConfigurationPlatform(BuildConfiguration.Debug, CpuConfiguration.x86),
                new SolutionConfigurationPlatform(BuildConfiguration.Release, CpuConfiguration.x86),
                new SolutionConfigurationPlatform(BuildConfiguration.Debug, CpuConfiguration.x64),
                new SolutionConfigurationPlatform(BuildConfiguration.Release, CpuConfiguration.x64)
            };
            var projectConfigurationPlatforms = new List<ProjectConfigurationPlatform>();
            foreach (var project in _projects)
            {
                var activeConfig = new ActiveConfigurationId();
                var buildConfig = new BuildConfigurationId(0);
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.Project.ProjectId, BuildConfiguration.Debug, CpuConfiguration.Any_CPU, activeConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.Project.ProjectId, BuildConfiguration.Debug, CpuConfiguration.Any_CPU, buildConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.Project.ProjectId, BuildConfiguration.Debug, CpuConfiguration.x64, activeConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.Project.ProjectId, BuildConfiguration.Debug, CpuConfiguration.x64, buildConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.Project.ProjectId, BuildConfiguration.Debug, CpuConfiguration.x86, activeConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.Project.ProjectId, BuildConfiguration.Debug, CpuConfiguration.x86, buildConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.Project.ProjectId, BuildConfiguration.Release, CpuConfiguration.Any_CPU, activeConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.Project.ProjectId, BuildConfiguration.Release, CpuConfiguration.Any_CPU, buildConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.Project.ProjectId, BuildConfiguration.Release, CpuConfiguration.x64, activeConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.Project.ProjectId, BuildConfiguration.Release, CpuConfiguration.x64, buildConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.Project.ProjectId, BuildConfiguration.Release, CpuConfiguration.x86, activeConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.Project.ProjectId, BuildConfiguration.Release, CpuConfiguration.x86, buildConfig));
            }
            return new GlobalSection(solutionConfigurationPlatforms, projectConfigurationPlatforms, new SolutionProperties(false), new ExtensibilityGlobals(_solutionGuid));
        }
    }
}