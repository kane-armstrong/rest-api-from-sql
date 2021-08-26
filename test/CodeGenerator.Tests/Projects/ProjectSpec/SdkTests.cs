using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Projects.ProjectSpec
{
    public class SdkTests
    {
        [Fact]
        public void Sdk_defaults_to_microsoft_net_sdk_web()
        {
            const string sdk = "Microsoft.NET.Sdk.Web";
            var sut = new ProjectBuilder().Build();
            sut.Sdk.Should().Be(sdk);
        }

        [Fact]
        public void Sdk_is_rendered_correctly()
        {
            const string sdk = "Microsoft.NET.Sdk.Web";
            var sut = new ProjectBuilder().Build();
            var result = sut.Render();
            result.Should().Contain($"<Project Sdk=\"{sdk}\">");
        }

        [Fact]
        public void Setting_sdk_sets_the_sdk_correctly()
        {
            const string sdk = "Microsoft.NET.Sdk";
            var sut = new ProjectBuilder().Build();
            sut.SetSdk(sdk);
            sut.Sdk.Should().Be(sdk);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void An_argument_exception_is_thrown_when_setting_an_invalid_sdk(string value)
        {
            var sut = new ProjectBuilder().Build();
            Assert.Throws<ArgumentException>(() => sut.SetSdk(value));
        }
    }
}
