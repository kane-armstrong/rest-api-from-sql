using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class NameTests
    {
        [Theory]
        [InlineData("MyTestClass")]
        [InlineData("_MyTestClass")]
        [InlineData("MyTestClass1")]
        [InlineData("_")]
        [InlineData("My_test_class")]
        public void Class_name_is_set_correctly(string value)
        {
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName(value)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain($"class {value}");
        }

        [Fact]
        public void The_most_recently_configured_class_name_is_used()
        {
            var sut = new ClassBuilder();
            const string name1 = "MyTestClassName";
            const string name2 = "MyTestClassName2";
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName(name1)
                .WithName(name2)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
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
        [InlineData("MyTestNamespace.TheThing")]
        public void An_argument_exception_is_thrown_when_the_class_name_is_invalid(string value)
        {
            var sut = new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public);
            Assert.Throws<ArgumentException>(() => sut.WithName(value));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_a_class_name_is_not_provided()
        {
            var sut = new ClassBuilder()
                .WithName("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public);
            Assert.Throws<InvalidOperationException>(() => sut.Build());
        }
    }
}
