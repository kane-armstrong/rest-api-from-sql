using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class FieldTests
    {
        [Theory]
        [InlineData("MyTestField")]
        [InlineData("_MyTestField")]
        [InlineData("MyTestField1")]
        [InlineData("_")]
        [InlineData("My_test_field")]
        public void A_single_field_is_added_correctly(string value)
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
        public void Multiple_fields_are_added_correctly()
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

        [Fact]
        public void Fields_with_values_are_rendered_correctly()
        {
            var sut = new ClassBuilder();
            var field = new FieldDefinition("string", "TheMeaning", " = 42;");
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithField(field)
                .Build();
            result.Should().Contain($"private {field.Type} {field.Name} = 42;");
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
        public void An_argument_exception_is_thrown_when_the_field_name_is_invalid(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<ArgumentException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithField(new FieldDefinition("void", value)));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_the_field_has_already_been_added()
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
        public void An_invalid_operation_exception_is_thrown_when_adding_a_field_with_the_same_name_as_the_enclosing_type()
        {
            var sut = new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass");
            Assert.Throws<InvalidOperationException>(() => sut.WithField(new FieldDefinition("string", "MyClass")));
        }
    }
}
