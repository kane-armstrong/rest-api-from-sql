using System;
using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassBuilderSpec
{
    public class NamespaceTests
    {
        [Theory]
        [InlineData("MyTestNamespace")]
        [InlineData("_MyTestNamespace")]
        [InlineData("MyTestNamespace1")]
        [InlineData("_")]
        [InlineData("My_test_namespace")]
        [InlineData("MyTestNamespace.TheThing")]
        public void Namespace_is_set_correctly(string value)
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
        public void The_most_recently_configured_namespace_is_used()
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
        public void An_argument_exception_is_thrown_when_the_namespace_is_invalid(string value)
        {
            var sut = new ClassBuilder()
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public);

            Assert.Throws<ArgumentException>(() => sut.WithNamespace(value));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_the_namespace_is_not_provided()
        {
            var sut = new ClassBuilder()
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public);
            Assert.Throws<InvalidOperationException>(() => sut.Build());
        }
    }
}
