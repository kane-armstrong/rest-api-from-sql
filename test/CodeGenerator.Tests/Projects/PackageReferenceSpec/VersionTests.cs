using CodeGenerator.Projects;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Projects.PackageReferenceSpec;

public class VersionTests
{
    [Fact]
    public void Version_is_optional()
    {
        var sut = new PackageReference("MyReference");
        sut.Version.Should().BeNull();
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void An_argument_exception_is_thrown_when_version_is_invalid(string value)
    {
        Assert.Throws<ArgumentException>(() => new PackageReference("MyReference", value));
    }
}