using Antlr4.StringTemplate;
using CodeGenerator.Projects;
using CodeGenerator.Solutions.Templates;
using CodeGenerator.Solutions.Templates.Resources;

namespace CodeGenerator.Solutions;

public class ProjectSection
{
    public Project Project { get; }

    public ProjectSection(Project project)
    {
        Project = project;
    }

    public string Render()
    {
        var template = new Template(TemplateContent.ProjectSection, '$', '$');
        template.Add(ProjectSectionAttributes.ProjectTypeId, Project.ProjectTypeId.ToString().ToUpper());
        template.Add(ProjectSectionAttributes.ProjectName, Project.Name);
        // TODO Project relative path should ideally support e.g. putting it in src or test
        template.Add(ProjectSectionAttributes.ProjectRelativePath, @$"{Project.Name}\{Project.Name}.csproj");
        template.Add(ProjectSectionAttributes.ProjectId, Project.ProjectId.ToString().ToUpper());
        return template.Render();
    }
}