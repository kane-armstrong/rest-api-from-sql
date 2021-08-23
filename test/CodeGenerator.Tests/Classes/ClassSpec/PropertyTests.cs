using CodeGenerator.Classes;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassSpec
{
    public class PropertyTests
    {
        [Theory]
        [InlineData("MyTestProperty")]
        [InlineData("_MyTestProperty")]
        [InlineData("MyTestProperty1")]
        [InlineData("_")]
        [InlineData("My_test_property")]
        public void A_single_property_is_added_correctly(string value)
        {
            var prop = new Property("string", value);
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddProperty(prop);
            sut.Properties.Should().Contain(prop);
        }

        [Theory]
        [InlineData("MyTestProperty")]
        [InlineData("_MyTestProperty")]
        [InlineData("MyTestProperty1")]
        [InlineData("_")]
        [InlineData("My_test_property")]
        public void A_single_property_is_rendered_correctly(string value)
        {
            var prop = new Property("string", value);
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddProperty(prop);
            var result = sut.Render();
            result.Should().Contain($"{prop.Type} {prop.Name} ");
        }

        [Fact]
        public void Multiple_properties_are_added_correctly()
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            var prop1 = new Property("string", "MyProperty1");
            var prop2 = new Property("string", "MyProperty2");
            sut.AddProperty(prop1);
            sut.AddProperty(prop2);
            sut.Properties.Should().Contain(prop1);
            sut.Properties.Should().Contain(prop2);
        }

        [Fact]
        public void A_property_with_a_value_is_rendered_correctly()
        {
            var prop = new Property("string", "MyProperty1", "=> \"things\";");
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddProperty(prop);
            var result = sut.Render();
            result.Should().Contain($"{prop.Type} {prop.Name} => \"things\";");
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("123")]
        [InlineData(".")]
        [InlineData(".abc")]
        [InlineData("1abc")]
        [InlineData("A property")]
        [InlineData("MyTestProperty.TheThing")]
        public void An_argument_exception_is_thrown_when_property_name_is_invalid(string value)
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            Assert.Throws<ArgumentException>(() => sut.AddProperty(new Property("void", value)));
            // TODO property name validation should move, see comment on FieldTests
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_a_property_with_the_same_name_has_already_been_added()
        {
            var prop = new Property("string", "MyProperty");
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddProperty(prop);
            Assert.Throws<InvalidOperationException>(() => sut.AddProperty(prop));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_the_property_name_is_the_same_as_the_enclosing_type()
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            Assert.Throws<InvalidOperationException>(() => sut.AddProperty(new Property("string", "MyClass")));
        }
    }
}
