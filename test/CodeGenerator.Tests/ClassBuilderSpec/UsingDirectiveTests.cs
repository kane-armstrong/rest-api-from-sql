using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class UsingDirectiveTests
    {
        [Theory]
        [InlineData("MyTestClass")]
        [InlineData("_MyTestClass")]
        [InlineData("MyTestClass1")]
        [InlineData("_")]
        [InlineData("My_test_namespace")]
        [InlineData("MyTestNamespace.TheThing")]
        public void A_single_using_directive_is_added_correctly(string value)
        {
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .UsingNamespace(value)
                .Build();
            result.Should().Contain($"using {value};");
        }

        [Fact]
        public void Multiple_using_directives_are_added_correctly()
        {
            var sut = new ClassBuilder();
            const string ns1 = "MyTestNamespace.Test";
            const string ns2 = "MyTestNamespace.Test2";
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
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
        public void An_argument_exception_is_thrown_when_the_namespace_is_invalid(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<ArgumentException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .UsingNamespace(value));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_adding_a_using_directive_that_has_already_been_added()
        {
            const string ns1 = "MyTestNamespace.Test";
            const string ns2 = "MyTestNamespace.Test";
            var sut = new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .UsingNamespace(ns1);
            Assert.Throws<InvalidOperationException>(() => sut.UsingNamespace(ns2));
        }
    }
}
