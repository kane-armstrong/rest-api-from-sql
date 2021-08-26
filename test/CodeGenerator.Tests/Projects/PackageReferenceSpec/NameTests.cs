using CodeGenerator.Projects;
using System;
using Xunit;

namespace CodeGenerator.Tests.Projects.PackageReferenceSpec
{
    public class PackageReferenceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void An_argument_exception_is_thrown_when_name_is_invalid_and_version_is_provided(string value)
        {
            Assert.Throws<ArgumentException>(() => new PackageReference(value, "1.0.0"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void An_argument_exception_is_thrown_when_name_is_invalid_and_version_is_not_provided(string value)
        {
            Assert.Throws<ArgumentException>(() => new PackageReference(value));
        }
    }
}
