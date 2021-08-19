using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class WithBaseClassTests
    {
        [Theory]
        [InlineData("MyTestClass")]
        [InlineData("_MyTestClass")]
        [InlineData("MyTestClass1")]
        [InlineData("_")]
        [InlineData("My_test_class")]
        public void Builder_adds_base_class_correctly(string value)
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
        public void Builder_uses_most_recently_configured_base_class()
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
        public void Builder_throws_argument_exception_when_base_class_name_is_invalid(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<ArgumentException>(() => sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithBaseClass(value)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public));
        }
    }
}
