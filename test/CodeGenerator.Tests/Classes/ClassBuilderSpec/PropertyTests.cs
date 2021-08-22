using System;
using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassBuilderSpec
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
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithProperty(prop)
                .Build();
            result.Should().Contain($"{prop.Type} {prop.Name} ");
        }

        [Fact]
        public void Multiple_properties_are_added_correctly()
        {
            var sut = new ClassBuilder();
            var prop1 = new Property("string", "MyProperty1");
            var prop2 = new Property("string", "MyProperty2");
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithProperty(prop1)
                .WithProperty(prop2)
                .Build();
            result.Should().Contain($"{prop1.Type} {prop1.Name} ");
            result.Should().Contain($"{prop2.Type} {prop2.Name} ");
        }

        [Fact]
        public void A_property_with_a_value_is_rendered_correctly()
        {
            var sut = new ClassBuilder();
            var prop = new Property("string", "MyProperty1", "=> \"things\";");
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithProperty(prop)
                .Build();
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
            var sut = new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass");
            Assert.Throws<ArgumentException>(() => sut.WithProperty(new Property("void", value)));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_a_property_with_the_same_name_has_already_been_added()
        {
            var prop = new Property("string", "MyProperty");
            var sut = new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithProperty(prop);
            Assert.Throws<InvalidOperationException>(() => sut.WithProperty(prop));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_the_property_name_is_the_same_as_the_enclosing_type()
        {
            var sut = new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass");
            Assert.Throws<InvalidOperationException>(() => sut.WithProperty(new Property("string", "MyClass")));
        }
    }
}
