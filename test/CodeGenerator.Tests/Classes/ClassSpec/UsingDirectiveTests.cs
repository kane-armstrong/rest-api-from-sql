using System;
using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassSpec
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
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddUsingDirective(value);
            sut.UsingDirectives.Should().Contain(value);
        }

        [Theory]
        [InlineData("MyTestClass")]
        [InlineData("_MyTestClass")]
        [InlineData("MyTestClass1")]
        [InlineData("_")]
        [InlineData("My_test_namespace")]
        [InlineData("MyTestNamespace.TheThing")]
        public void A_single_using_directive_is_rendered_correctly(string value)
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddUsingDirective(value);
            var result = sut.Render();
            result.Should().Contain($"using {value};");
        }

        [Fact]
        public void Multiple_using_directives_are_added_correctly()
        {
            const string ns1 = "MyTestNamespace.Test";
            const string ns2 = "MyTestNamespace.Test2";
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddUsingDirective(ns1);
            sut.AddUsingDirective(ns2);
            sut.UsingDirectives.Should().Contain(ns1);
            sut.UsingDirectives.Should().Contain(ns2);
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
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            Assert.Throws<ArgumentException>(() => sut.AddUsingDirective(value));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_adding_a_using_directive_that_has_already_been_added()
        {
            const string ns = "MyTestNamespace.Test";
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddUsingDirective(ns);
            Assert.Throws<InvalidOperationException>(() => sut.AddUsingDirective(ns));
        }
    }
}
