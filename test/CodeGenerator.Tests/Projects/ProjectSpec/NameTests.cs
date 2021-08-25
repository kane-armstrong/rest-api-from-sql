using CodeGenerator.Projects;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Projects.ProjectSpec
{
    public class NameTests
    {
        [Theory]
        [InlineData("MyProject")]
        public void Project_name_is_set_correctly(string value)
        {
            var sut = new ProjectBuilder().WithName(value).Build();
            sut.Name.Should().Be(value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void An_argument_exception_is_thrown_for_invalid_project_names(string value)
        {
            Assert.Throws<ArgumentException>(() => new Project(value, "net5.0", @"C:\projects"));
        }
    }
}
