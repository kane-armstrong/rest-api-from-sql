using CodeGenerator.Classes;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassSpec
{
    public class BaseClassTests
    {
        [Theory]
        [InlineData("MyTestClass")]
        [InlineData("_MyTestClass")]
        [InlineData("MyTestClass1")]
        [InlineData("_")]
        [InlineData("My_test_class")]
        public void Base_class_is_added_correctly(string value)
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddBaseClass(value);
            sut.BaseClass.Should().Be(value);
        }

        [Theory]
        [InlineData("MyTestClass")]
        [InlineData("_MyTestClass")]
        [InlineData("MyTestClass1")]
        [InlineData("_")]
        [InlineData("My_test_class")]
        public void Base_class_is_rendered_correctly(string value)
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddBaseClass(value);
            sut.BaseClass.Should().Be(value);
            sut.Render().Should().Contain($"public class MyClass : {value}");
        }

        [Fact]
        public void The_most_recently_configured_base_class_is_used()
        {
            const string baseClassName = "MyBaseClass";
            const string newBaseClassName = "MyBaseClass2";
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddBaseClass(baseClassName);
            sut.AddBaseClass(newBaseClassName);
            sut.BaseClass.Should().Be(newBaseClassName);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("123")]
        [InlineData(".")]
        [InlineData(".abc")]
        [InlineData("1abc")]
        [InlineData("A base class")]
        [InlineData("MyTestBaseClass.TheThing")]
        public void An_argument_exception_is_thrown_when_base_class_name_is_invalid(string value)
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            Assert.Throws<ArgumentException>(() => sut.AddBaseClass(value));
        }
    }
}
