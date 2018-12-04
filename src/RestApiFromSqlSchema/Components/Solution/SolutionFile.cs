using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Antlr4.StringTemplate;
using Armsoft.RestApiFromSqlSchema.Components.Projects;
using Armsoft.RestApiFromSqlSchema.Components.Projects.Templates;
using Armsoft.RestApiFromSqlSchema.Components.Projects.Templates.Resources;
using Armsoft.RestApiFromSqlSchema.Components.Solution.Global;
using Armsoft.RestApiFromSqlSchema.Components.Solution.Global.Enumerations;
using Armsoft.RestApiFromSqlSchema.Components.Solution.Global.Sections;

namespace Armsoft.RestApiFromSqlSchema.Components.Solution
{
    public class SolutionFile
    {
        private const char StartDelim = '$';
        private const char EndDelim = '$';

        private readonly Guid _sharedProjectId;
        private readonly Guid _solutionGuid;
        private readonly List<ProjectFile> _projects;

        public readonly string SolutionDirectory;
        public readonly string SolutionName;

        private string SolutionPath => $"{SolutionDirectory}\\{SolutionName}.sln";

        public SolutionFile(string directory, string name)
        {
            _projects = new List<ProjectFile>();
            SolutionDirectory = directory;
            SolutionName = name;
            _solutionGuid = Guid.NewGuid();
            _sharedProjectId = Guid.NewGuid();
        }

        private string GenerateProjectRootPath(ProjectFile project) => $"{SolutionDirectory}\\{project.Name}";

        public void AddProject(ProjectFile project)
        {
            if (_projects.Any(x => x.Name.Equals(project.Name, StringComparison.InvariantCultureIgnoreCase)))
            {
                throw new SolutionGenerationException(string.Format(SharedResources.AddProjectNameCollisionException, nameof(project.Name), project.Name));
            }

            project.Id = _sharedProjectId;
            _projects.Add(project);
        }

        public void SaveChanges()
        {
            CreateDirectories();
            SaveSolutionFile();
            SaveProjectSourceFiles();
        }

        private void SaveProjectSourceFiles()
        {
            foreach (var projectFile in _projects)
            {
                var root = $"{GenerateProjectRootPath(projectFile)}";
                foreach (var file in projectFile.ClassFiles)
                {
                    var filePath = $"{root}\\{file.RelativePath}\\{file.FileName}";
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }

                    File.AppendAllText(filePath, file.FileContent);
                }
            }
        }

        private void CreateDirectories()
        {
            CreateDirectoryIfNotExists(SolutionDirectory);
            foreach (var projectFile in _projects)
            {
                var root = GenerateProjectRootPath(projectFile);
                CreateDirectoryIfNotExists(root);
                foreach (var file in projectFile.ClassFiles)
                {
                    CreateDirectoryIfNotExists($"{root}\\{file.RelativePath}");
                }
            }
        }

        private void SaveSolutionFile()
        {
            if (File.Exists(SolutionPath))
            {
                File.Delete(SolutionPath);
            }

            var solutionFileContent = GenerateSolutionFileContent();
            File.AppendAllText(SolutionPath, solutionFileContent);
        }

        private string GenerateSolutionFileContent()
        {
            var projectSectionsBuilder = new StringBuilder();
            foreach (var project in _projects)
            {
                projectSectionsBuilder.AppendLine(GenerateProjectFileContent(project, SolutionDirectory));
            }

            string projectsSection;
            string globalSection;

            if (!_projects.Any())
            {
                projectsSection = "";
                globalSection = "";
            }
            else
            {
                projectsSection = projectSectionsBuilder.ToString();
                globalSection = GenerateGlobalSection().ToString();
            }

            var template = new Template(TemplateContent.Solution, StartDelim, EndDelim);

            template.Add(TemplateKeys.ProjectConfigurations, projectsSection);
            template.Add(TemplateKeys.GlobalSection, globalSection);

            return template.Render();
        }

        private string GenerateProjectFileContent(ProjectFile project, string solutionDirectory)
        {
            var template = new Template(TemplateContent.ProjectSection, '$', '$');
            template.Add(TemplateKeys.ProjectId, project.Id.ToString().ToUpper());
            template.Add(TemplateKeys.ProjectName, project.Name);
            template.Add(TemplateKeys.ProjectRelativePath, $"{solutionDirectory}\\{project.Name}\\{project.FileName}");
            template.Add(TemplateKeys.SectionId, project.SectionId.ToString().ToUpper());
            return template.Render();
        }

        private static void CreateDirectoryIfNotExists(string path)
        {
            if (Directory.Exists(path))
            {
                return;
            }
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {
                throw new SolutionGenerationException(SharedResources.CreateSolutionDirectoryGeneralException, e);
            }
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
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.SectionId, BuildConfiguration.Debug, CpuConfiguration.Any_CPU, activeConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.SectionId, BuildConfiguration.Debug, CpuConfiguration.Any_CPU, buildConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.SectionId, BuildConfiguration.Debug, CpuConfiguration.x64, activeConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.SectionId, BuildConfiguration.Debug, CpuConfiguration.x64, buildConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.SectionId, BuildConfiguration.Debug, CpuConfiguration.x86, activeConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.SectionId, BuildConfiguration.Debug, CpuConfiguration.x86, buildConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.SectionId, BuildConfiguration.Release, CpuConfiguration.Any_CPU, activeConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.SectionId, BuildConfiguration.Release, CpuConfiguration.Any_CPU, buildConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.SectionId, BuildConfiguration.Release, CpuConfiguration.x64, activeConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.SectionId, BuildConfiguration.Release, CpuConfiguration.x64, buildConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.SectionId, BuildConfiguration.Release, CpuConfiguration.x86, activeConfig));
                projectConfigurationPlatforms.Add(new ProjectConfigurationPlatform(project.SectionId, BuildConfiguration.Release, CpuConfiguration.x86, buildConfig));
            }
            return new GlobalSection(solutionConfigurationPlatforms, projectConfigurationPlatforms, new SolutionProperties(false), new ExtensibilityGlobals(_solutionGuid));
        }
    }
}