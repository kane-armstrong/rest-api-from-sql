using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class WithNameTests
    {
        [Fact]
        public void Builder_sets_name_correctly()
        {
            var sut = new ClassBuilder();
            const string className = "MyTestClassName";
            var result = sut.WithNamespace("MyNamespace").WithName(className).Build();
            result.Should().Contain($"class {className}");
        }

        [Fact]
        public void Builder_uses_most_recently_configured_name()
        {
            var sut = new ClassBuilder();
            const string name1 = "MyTestClassName";
            const string name2 = "MyTestClassName2";
            var result = sut.WithNamespace("MyNamespace").WithName(name1).WithName(name2).Build();
            result.Should().Contain($"class {name2}");
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("123")]
        [InlineData(".")]
        [InlineData(".abc")]
        [InlineData("1abc")]
        [InlineData("A class name")]
        public void Builder_throws_invalid_operation_exception_when_name_could_never_compile(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut.WithNamespace("MyNamespace").WithName(value));
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_namespace_is_not_provided()
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut.WithNamespace("MyNamespace").Build());
        }
    }
}
