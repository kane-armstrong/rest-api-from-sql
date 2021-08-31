using CodeGenerator.Solutions;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Solutions.SolutionSpec
{
    public class NameTests
    {
        [Fact]
        public void Name_is_set_correctly()
        {
            const string name = "MySolution";
            var sut = new Solution(@"C:\test", name);
            sut.Name.Should().Be(name);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void An_argument_exception_is_thrown_for_invalid_names(string value)
        {
            Assert.Throws<ArgumentException>(() => new Solution(@"C:\test", value));
        }
    }
}
