using CodeGenerator.Classes;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassSpec
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
            var field = new Field("string", value);
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddField(field);
            sut.Fields.Should().Contain(field);
        }

        [Theory]
        [InlineData("MyTestField")]
        [InlineData("_MyTestField")]
        [InlineData("MyTestField1")]
        [InlineData("_")]
        [InlineData("My_test_field")]
        public void A_single_field_is_rendered_correctly(string value)
        {
            var field = new Field("string", value);
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddField(field);
            var result = sut.Render();
            result.Should().Contain($"private {field.Type} {field.Name};");
        }

        [Fact]
        public void Multiple_fields_are_added_correctly()
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            var field1 = new Field("string", "MyField1");
            var field2 = new Field("string", "MyField2");
            sut.AddField(field1);
            sut.AddField(field2);
            sut.Fields.Should().Contain(field1);
            sut.Fields.Should().Contain(field2);
        }

        [Fact]
        public void Fields_with_values_are_rendered_correctly()
        {
            var field = new Field("string", "TheMeaning", " = 42;");
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddField(field);
            var result = sut.Render();
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
            // TODO this validation should live in the field ctor... perhaps in a new type presenting validated type names
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            Assert.Throws<ArgumentException>(() => sut.AddField(new Field("void", value)));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_the_field_has_already_been_added()
        {
            var field = new Field("string", "MyField");
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddField(field);
            Assert.Throws<InvalidOperationException>(() => sut.AddField(field));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_adding_a_field_with_the_same_name_as_the_enclosing_type()
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            Assert.Throws<InvalidOperationException>(() => sut.AddField(new Field("string", "MyClass")));
        }
    }
}
