using CodeGenerator.Solutions;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Solutions.SolutionSpec
{
    public class DirectoryTests
    {
        [Fact]
        public void Directory_is_set_correctly()
        {
            const string directory = @"C:\test";
            var sut = new Solution(directory, "MySolution");
            sut.Directory.Should().Be(directory);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void An_argument_exception_is_thrown_for_invalid_directory(string value)
        {
            Assert.Throws<ArgumentException>(() => new Solution(value, "MySolution"));
        }
    }
}
