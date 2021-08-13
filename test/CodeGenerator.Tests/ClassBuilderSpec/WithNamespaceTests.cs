using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class WithNamespaceTests
    {
        [Theory]
        [InlineData("MyTestNamespace")]
        [InlineData("_MyTestNamespace")]
        [InlineData("MyTestNamespace1")]
        [InlineData("_")]
        [InlineData("My_test_namespace")]
        [InlineData("MyTestNamespace.TheThing")]
        public void Builder_sets_namespace_correctly(string value)
        {
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace(value)
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain($"namespace {value}");
        }

        [Fact]
        public void Builder_uses_most_recently_configured_namespace()
        {
            var sut = new ClassBuilder();
            const string ns1 = "MyTestNamespace";
            const string ns2 = "MyTestNamespace2";
            var result = sut
                .WithName("MyClass")
                .WithNamespace(ns1)
                .WithNamespace(ns2)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain($"namespace {ns2}");
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
        [InlineData("MyTestNamespace.The Thing")]
        public void Builder_throws_invalid_operation_exception_when_namespace_could_never_compile(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithName("MyClass")
                .WithNamespace(value)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public));
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_namespace_is_not_provided()
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build());
        }
    }
}
