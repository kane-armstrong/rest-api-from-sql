using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
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
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithBaseClass(value)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain($"public class MyClass : {value}");
        }

        [Fact]
        public void The_most_recently_configured_base_class_is_used()
        {
            const string baseClassName = "MyBaseClass";
            const string newBaseClassName = "MyBaseClass2";
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithBaseClass(baseClassName)
                .WithBaseClass(newBaseClassName)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain($"public class MyClass : {newBaseClassName}");
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
            var sut = new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public);
            Assert.Throws<ArgumentException>(() => sut.WithBaseClass(value));
        }
    }
}
