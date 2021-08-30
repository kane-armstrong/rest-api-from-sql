using CodeGenerator.Projects;
using CodeGenerator.Solutions;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Solutions.SolutionSpec
{
    public class SolutionTests
    {
        [Fact]
        public void Solutions_with_a_single_project_render_correctly()
        {
            var sut = new Solution(@"c:\temp", "MySolution");
            var project = new Project("MyProject", "net5.0");
            sut.AddProject(project);

            var projectTypeId = project.ProjectTypeId.ToString().ToUpper();
            var projectId = project.ProjectId.ToString().ToUpper();
            var solutionGuid = sut.SolutionGuid.ToString().ToUpper();

            var result = sut.Render();
            result.Should().Be($@"Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.26730.16
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{{{projectTypeId}}}"") = ""MyProject"", ""MyProject\MyProject.csproj"", ""{{{projectId}}}""
EndProject
Global
    GlobalSection(SolutionConfigurationPlatforms) = preSolution
        Debug|Any CPU = Debug|Any CPU
        Release|Any CPU = Release|Any CPU
        Debug|x86 = Debug|x86
        Release|x86 = Release|x86
        Debug|x64 = Debug|x64
        Release|x64 = Release|x64
    EndGlobalSection
    GlobalSection(ProjectConfigurationPlatforms) = postSolution
        {{{projectId}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {{{projectId}}}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {{{projectId}}}.Debug|x64.ActiveCfg = Debug|x64
        {{{projectId}}}.Debug|x64.Build.0 = Debug|x64
        {{{projectId}}}.Debug|x86.ActiveCfg = Debug|x86
        {{{projectId}}}.Debug|x86.Build.0 = Debug|x86
        {{{projectId}}}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {{{projectId}}}.Release|Any CPU.Build.0 = Release|Any CPU
        {{{projectId}}}.Release|x64.ActiveCfg = Release|x64
        {{{projectId}}}.Release|x64.Build.0 = Release|x64
        {{{projectId}}}.Release|x86.ActiveCfg = Release|x86
        {{{projectId}}}.Release|x86.Build.0 = Release|x86
    EndGlobalSection
    GlobalSection(SolutionProperties) = preSolution
        HideSolutionNode = FALSE
    EndGlobalSection
    GlobalSection(ExtensibilityGlobals) = postSolution
        SolutionGuid = {{{solutionGuid}}}
    EndGlobalSection
EndGlobal
");
        }

        [Fact]
        public void Solutions_with_multiple_projects_render_correctly()
        {
            var sut = new Solution(@"c:\temp", "MySolution");
            
            var project1 = new Project("MyProject1", "net5.0");
            var project2 = new Project("MyProject2", "net5.0");
            
            sut.AddProject(project1);
            sut.AddProject(project2);

            var solutionGuid = sut.SolutionGuid.ToString().ToUpper();
            
            var projectTypeId1 = project1.ProjectTypeId.ToString().ToUpper();
            var projectId1 = project1.ProjectId.ToString().ToUpper();

            var projectTypeId2 = project2.ProjectTypeId.ToString().ToUpper();
            var projectId2 = project2.ProjectId.ToString().ToUpper();

            var result = sut.Render();
            result.Should().Be($@"Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.26730.16
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{{{projectTypeId1}}}"") = ""MyProject1"", ""MyProject1\MyProject1.csproj"", ""{{{projectId1}}}""
EndProject
Project(""{{{projectTypeId2}}}"") = ""MyProject2"", ""MyProject2\MyProject2.csproj"", ""{{{projectId2}}}""
EndProject
Global
    GlobalSection(SolutionConfigurationPlatforms) = preSolution
        Debug|Any CPU = Debug|Any CPU
        Release|Any CPU = Release|Any CPU
        Debug|x86 = Debug|x86
        Release|x86 = Release|x86
        Debug|x64 = Debug|x64
        Release|x64 = Release|x64
    EndGlobalSection
    GlobalSection(ProjectConfigurationPlatforms) = postSolution
        {{{projectId1}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {{{projectId1}}}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {{{projectId1}}}.Debug|x64.ActiveCfg = Debug|x64
        {{{projectId1}}}.Debug|x64.Build.0 = Debug|x64
        {{{projectId1}}}.Debug|x86.ActiveCfg = Debug|x86
        {{{projectId1}}}.Debug|x86.Build.0 = Debug|x86
        {{{projectId1}}}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {{{projectId1}}}.Release|Any CPU.Build.0 = Release|Any CPU
        {{{projectId1}}}.Release|x64.ActiveCfg = Release|x64
        {{{projectId1}}}.Release|x64.Build.0 = Release|x64
        {{{projectId1}}}.Release|x86.ActiveCfg = Release|x86
        {{{projectId1}}}.Release|x86.Build.0 = Release|x86
        {{{projectId2}}}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {{{projectId2}}}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {{{projectId2}}}.Debug|x64.ActiveCfg = Debug|x64
        {{{projectId2}}}.Debug|x64.Build.0 = Debug|x64
        {{{projectId2}}}.Debug|x86.ActiveCfg = Debug|x86
        {{{projectId2}}}.Debug|x86.Build.0 = Debug|x86
        {{{projectId2}}}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {{{projectId2}}}.Release|Any CPU.Build.0 = Release|Any CPU
        {{{projectId2}}}.Release|x64.ActiveCfg = Release|x64
        {{{projectId2}}}.Release|x64.Build.0 = Release|x64
        {{{projectId2}}}.Release|x86.ActiveCfg = Release|x86
        {{{projectId2}}}.Release|x86.Build.0 = Release|x86
    EndGlobalSection
    GlobalSection(SolutionProperties) = preSolution
        HideSolutionNode = FALSE
    EndGlobalSection
    GlobalSection(ExtensibilityGlobals) = postSolution
        SolutionGuid = {{{solutionGuid}}}
    EndGlobalSection
EndGlobal
");
        }

        [Fact]
        public void Empty_solutions_are_rendered_in_the_correct_format()
        {
            var sut = new Solution(@"c:\temp", "MySolution");
            var result = sut.Render();
            result.Should().Be(@"Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.26730.16
MinimumVisualStudioVersion = 10.0.40219.1
");
        }
    }
}
