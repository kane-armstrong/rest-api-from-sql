using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class AttributeTests
    {
        [Fact]
        public void A_single_attribute_is_added_correctly()
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
        public void Multiple_attributes_are_added_correctly()
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
        public void An_argument_exception_is_thrown_when_the_attribute_is_invalid(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<ArgumentException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithAttribute(value));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_the_attribute_has_already_been_added()
        {
            const string attribute = "[Table(\"SomeTableName\")]";
            var sut = new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithAttribute(attribute);
            Assert.Throws<InvalidOperationException>(() => sut.WithAttribute(attribute));
        }
    }
}
