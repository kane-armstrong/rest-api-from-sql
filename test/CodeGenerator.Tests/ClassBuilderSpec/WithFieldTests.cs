using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class WithFieldTests
    {
        [Theory]
        [InlineData("MyTestField")]
        [InlineData("_MyTestField")]
        [InlineData("MyTestField1")]
        [InlineData("_")]
        [InlineData("My_test_field")]
        public void Builder_adds_single_field_correctly(string value)
        {
            var field = new FieldDefinition("string", value);
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithField(field)
                .Build();
            result.Should().Contain($"private {field.Type} {field.Name};");
        }

        [Fact]
        public void Builder_adds_multiple_fields_correctly()
        {
            var sut = new ClassBuilder();
            var field1 = new FieldDefinition("string", "MyField1");
            var field2 = new FieldDefinition("string", "MyField2");
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithField(field1)
                .WithField(field2)
                .Build();
            result.Should().Contain($"private {field1.Type} {field1.Name};");
            result.Should().Contain($"private {field2.Type} {field2.Name};");
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("123")]
        [InlineData(".")]
        [InlineData(".abc")]
        [InlineData("1abc")]
        [InlineData("A field")]
        [InlineData("MyTestField.TheThing")]
        public void Builder_throws_invalid_operation_exception_when_name_is_invalid(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithField(new FieldDefinition("void", value)));
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_field_already_added()
        {
            var sut = new ClassBuilder();
            var field = new FieldDefinition("string", "MyField");
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithField(field)
                .WithField(field));
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_name_is_the_same_as_the_enclosing_type()
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithField(new FieldDefinition("string", "MyClass")));
        }
    }
}
