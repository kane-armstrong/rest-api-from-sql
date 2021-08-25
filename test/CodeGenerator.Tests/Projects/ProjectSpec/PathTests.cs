using CodeGenerator.Projects;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Projects.ProjectSpec
{
    public class PathTests
    {
        [Theory]
        [InlineData(@"C:\projects")]
        public void Path_is_set_correctly(string value)
        {
            var sut = new ProjectBuilder().WithPath(value).Build();
            sut.Path.Should().Be(value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void An_argument_exception_is_thrown_for_invalid_directory_paths(string value)
        {
            Assert.Throws<ArgumentException>(() => new Project("MyProject", "net5.0", value));
        }
    }
}
