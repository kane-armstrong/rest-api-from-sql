using Antlr4.StringTemplate;
using CodeGenerator.Projects;
using System;
using CodeGenerator.Solutions.Templates;
using CodeGenerator.Solutions.Templates.Resources;

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
            template.Add(ProjectSectionAttributes.ProjectId, Id.ToString().ToUpper());
            template.Add(ProjectSectionAttributes.ProjectName, Project.Name);
            // TODO Project relative path should ideally support e.g. putting it in src or test
            template.Add(ProjectSectionAttributes.ProjectRelativePath, @$"{Project.Name}\{Project.Name}.csproj");
            template.Add(ProjectSectionAttributes.SectionId, SectionId.ToString().ToUpper());
            return template.Render();
        }
    }
}
