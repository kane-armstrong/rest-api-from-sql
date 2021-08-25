using Antlr4.StringTemplate;
using CodeGenerator.Projects;
using CodeGenerator.Projects.Templates;
using CodeGenerator.Projects.Templates.Resources;
using System;

namespace CodeGenerator.Solutions
{
    public class ProjectSection
    {
        private Guid Id { get; }
        public Guid SectionId { get; }
        public Project Project { get; }

        public ProjectSection(Project project, Guid id)
        {
            Project = project;
            Id = id;
            SectionId = Guid.NewGuid();
        }

        public string Render()
        {
            var template = new Template(TemplateContent.ProjectSection, '$', '$');
            template.Add(ProjectAttributes.ProjectId, Id.ToString().ToUpper());
            template.Add(ProjectAttributes.ProjectName, Project.Name);
            template.Add(ProjectAttributes.ProjectRelativePath, @$"{Project.Path}.csproj");
            template.Add(ProjectAttributes.SectionId, SectionId.ToString().ToUpper());
            return template.Render();
        }
    }
}
