using Antlr4.StringTemplate;
using CodeGenerator.Projects;
using CodeGenerator.Solutions.Global;
using CodeGenerator.Solutions.Global.Enumerations;
using CodeGenerator.Solutions.Global.Sections;
using CodeGenerator.Solutions.Templates;
using CodeGenerator.Solutions.Templates.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Solutions
{
    public class Solution
    {
        private const char StartDelimiter = '$';
        private const char EndDelimiter = '$';
        private readonly List<ProjectSection> _projects = new();

        public Guid Id { get; }
        public string Directory { get; }
        public string Name { get; }

        public Solution(string directory, string name)
        {
            if (string.IsNullOrEmpty(directory))
            {
                throw new ArgumentException(nameof(directory));
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(name));
            }
            
            Id = Guid.NewGuid();

            Directory = directory;
            Name = name;
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
            return new GlobalSection(solutionConfigurationPlatforms, projectConfigurationPlatforms, new SolutionProperties(false), new ExtensibilityGlobals(Id));
        }
    }
}