using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Projects.ProjectSpec
{
    public class SdkTests
    {
        [Fact]
        public void Sdk_defaults_to_microsoft_net_sdk_web()
        {
            var sut = new ProjectBuilder().Build();
            sut.Sdk.Should().Be("Microsoft.NET.Sdk.Web");
        }

        [Fact]
        public void Setting_sdk_sets_the_sdk_correctly()
        {
            const string sdk = "Microsoft.NET.Sdk";
            var sut = new ProjectBuilder().Build();
            sut.SetSdk(sdk);
            sut.Sdk.Should().Be(sdk);
        }

        [Fact]
        public void An_argument_exception_is_thrown_when_setting_an_invalid_sdk()
        {
            const string sdk = "Microsoft.NET.Sdk";
            var sut = new ProjectBuilder().Build();
            sut.SetSdk(sdk);
            sut.Sdk.Should().Be(sdk);
        }
    }
}
