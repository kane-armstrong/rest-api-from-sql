using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Projects.ProjectSpec;

public class ProjectIdTests
{
    [Fact]
    public void A_non_empty_project_id_is_created_when_creating_a_project()
    {
        var sut = new ProjectBuilder().Build();
        sut.ProjectId.Should().NotBeEmpty();
    }
}