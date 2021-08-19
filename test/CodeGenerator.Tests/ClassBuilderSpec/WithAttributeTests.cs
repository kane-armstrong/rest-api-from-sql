using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class WithAttributeTests
    {
        [Fact]
        public void Builder_adds_single_attribute_correctly()
        {
            const string attribute = "[Table(\"SomeTableName\")]";
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAttribute(attribute)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain(attribute);
        }

        [Fact]
        public void Builder_adds_multiple_attributes_correctly()
        {
            var sut = new ClassBuilder();
            const string attribute1 = "[Table(\"SomeTableName\")]";
            const string attribute2 = "[Serializable]";
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithAttribute(attribute1)
                .WithAttribute(attribute2)
                .Build();
            result.Should().Contain(attribute1);
            result.Should().Contain(attribute2);
        }

        [Theory]
        [InlineData(null)]
        public void Builder_throws_argument_exception_when_attribute_is_invalid(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<ArgumentException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithAttribute(value));
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_attribute_already_added()
        {
            var sut = new ClassBuilder();
            const string attribute = "[Table(\"SomeTableName\")]";
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithAttribute(attribute)
                .WithAttribute(attribute));
        }
    }
}
