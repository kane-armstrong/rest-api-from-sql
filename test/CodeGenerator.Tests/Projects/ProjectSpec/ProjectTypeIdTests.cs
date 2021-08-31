using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Projects.ProjectSpec
{
    public class ProjectTypeIdTests
    {
        [Fact]
        public void Project_type_id_defaults_to_new_project_system_csproj_id()
        {
            var sut = new ProjectBuilder().Build();
            var expected = Guid.Parse("9A19103F-16F7-4668-BE54-9A1E7A4F7556");
            sut.ProjectTypeId.Should().Be(expected);
        }
    }
}
