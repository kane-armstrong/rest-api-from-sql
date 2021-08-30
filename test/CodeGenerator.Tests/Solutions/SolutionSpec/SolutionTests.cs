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
            sut.AddProject(new Project("MyProject", "net5.0"));
            var result = sut.Render();
            result.Should().Be(@"Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 15
VisualStudioVersion = 15.0.26730.16
MinimumVisualStudioVersion = 10.0.40219.1
Project(""{DDD9EC38-C9AE-4F1D-8469-5663E57E5A21}"") = ""MyProject"", ""MyProject\MyProject.csproj"", ""{E228BE9B-919D-4A5A-A397-4C87C76FC707}""
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
        {E228BE9B-919D-4A5A-A397-4C87C76FC707}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
        {E228BE9B-919D-4A5A-A397-4C87C76FC707}.Debug|Any CPU.Build.0 = Debug|Any CPU
        {E228BE9B-919D-4A5A-A397-4C87C76FC707}.Debug|x64.ActiveCfg = Debug|x64
        {E228BE9B-919D-4A5A-A397-4C87C76FC707}.Debug|x64.Build.0 = Debug|x64
        {E228BE9B-919D-4A5A-A397-4C87C76FC707}.Debug|x86.ActiveCfg = Debug|x86
        {E228BE9B-919D-4A5A-A397-4C87C76FC707}.Debug|x86.Build.0 = Debug|x86
        {E228BE9B-919D-4A5A-A397-4C87C76FC707}.Release|Any CPU.ActiveCfg = Release|Any CPU
        {E228BE9B-919D-4A5A-A397-4C87C76FC707}.Release|Any CPU.Build.0 = Release|Any CPU
        {E228BE9B-919D-4A5A-A397-4C87C76FC707}.Release|x64.ActiveCfg = Release|x64
        {E228BE9B-919D-4A5A-A397-4C87C76FC707}.Release|x64.Build.0 = Release|x64
        {E228BE9B-919D-4A5A-A397-4C87C76FC707}.Release|x86.ActiveCfg = Release|x86
        {E228BE9B-919D-4A5A-A397-4C87C76FC707}.Release|x86.Build.0 = Release|x86
    EndGlobalSection
    GlobalSection(SolutionProperties) = preSolution
        HideSolutionNode = FALSE
    EndGlobalSection
    GlobalSection(ExtensibilityGlobals) = postSolution
        SolutionGuid = {5DDA706D-A6E6-44F2-8331-CC39B848D7E0}
    EndGlobalSection
EndGlobal");
        }

        [Fact]
        public void Solutions_with_multiple_projects_render_correctly()
        {
            var sut = new Solution(@"c:\temp", "MySolution");
            sut.AddProject(new Project("MyProject1", "net5.0"));
            sut.AddProject(new Project("MyProject2", "net5.0"));
            var result = sut.Render();
            result.Should().Be(@"");
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
