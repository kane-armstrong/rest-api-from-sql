using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class WithUsingDirectiveTests
    {
        [Theory]
        [InlineData("MyTestClass")]
        [InlineData("_MyTestClass")]
        [InlineData("MyTestClass1")]
        [InlineData("_")]
        [InlineData("My_test_namespace")]
        [InlineData("MyTestNamespace.TheThing")]
        public void Builder_adds_single_using_directive_correctly(string value)
        {
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .UsingNamespace(value)
                .Build();
            result.Should().Contain($"using {value};");
        }

        [Fact]
        public void Builder_adds_multiple_using_directives_correctly()
        {
            var sut = new ClassBuilder();
            const string ns1 = "MyTestNamespace.Test";
            const string ns2 = "MyTestNamespace.Test2";
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .UsingNamespace(ns1)
                .UsingNamespace(ns2)
                .Build();
            result.Should().Contain($"using {ns1};");
            result.Should().Contain($"using {ns2};");
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("123")]
        [InlineData(".")]
        [InlineData(".abc")]
        [InlineData("1abc")]
        [InlineData("A namespace")]
        public void Builder_throws_invalid_operation_exception_when_namespace_is_invalid(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .UsingNamespace(value));
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_namespace_already_added()
        {
            var sut = new ClassBuilder();
            const string ns1 = "MyTestNamespace.Test";
            const string ns2 = "MyTestNamespace.Test";
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .UsingNamespace(ns1)
                .UsingNamespace(ns2));
        }
    }
}
