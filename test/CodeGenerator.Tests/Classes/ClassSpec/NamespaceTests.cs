using CodeGenerator.Classes;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassSpec
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
            var sut = new Class(value, ClassAccessibilityLevel.Public, "MyClass");
            sut.Namespace.Should().Be(value);
        }

        [Theory]
        [InlineData("MyTestNamespace")]
        [InlineData("_MyTestNamespace")]
        [InlineData("MyTestNamespace1")]
        [InlineData("_")]
        [InlineData("My_test_namespace")]
        [InlineData("MyTestNamespace.TheThing")]
        public void Namespace_is_rendered_correctly(string value)
        {
            var sut = new Class(value, ClassAccessibilityLevel.Public, "MyClass");
            var result = sut.Render();
            result.Should().Contain($"namespace {value}");
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
            Assert.Throws<ArgumentException>(() => new Class(value, ClassAccessibilityLevel.Public, "MyClass"));
        }
    }
}
