using CodeGenerator.Projects;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Projects.ProjectSpec
{
    public class TargetFrameworkTests
    {
        [Fact]
        public void Target_framework_is_set_correctly()
        {
            const string tf = "netstandard2.1";
            var sut = new ProjectBuilder().WithTargetFramework(tf).Build();
            sut.TargetFramework.Should().Be(tf);
        }

        [Fact]
        public void Target_framework_is_rendered_correctly()
        {
            const string tf = "netstandard2.1";
            var sut = new ProjectBuilder().WithTargetFramework(tf).Build();
            var result = sut.Render();
            result.Should().Contain($"<TargetFramework>{tf}</TargetFramework>");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void An_argument_exception_is_thrown_when_setting_an_invalid_target_framework(string value)
        {
            Assert.Throws<ArgumentException>(() => new Project("MyProject", value));
        }
    }
}
