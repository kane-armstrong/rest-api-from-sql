using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class WithPropertyTests
    {
        [Theory]
        [InlineData("MyTestProperty")]
        [InlineData("_MyTestProperty")]
        [InlineData("MyTestProperty1")]
        [InlineData("_")]
        [InlineData("My_test_property")]
        public void Builder_adds_single_property_correctly(string value)
        {
            var prop = new PropertyDefinition("string", value);
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
        public void Builder_adds_multiple_properties_correctly()
        {
            var sut = new ClassBuilder();
            var prop1 = new PropertyDefinition("string", "MyProperty1");
            var prop2 = new PropertyDefinition("string", "MyProperty2");
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
        public void Builder_adds_property_with_value_correctly()
        {
            var sut = new ClassBuilder();
            var prop = new PropertyDefinition("string", "MyProperty1", " => \"things\";");
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
        public void Builder_throws_invalid_operation_exception_when_name_is_invalid(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithProperty(new PropertyDefinition("void", value)));
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_property_already_added()
        {
            var sut = new ClassBuilder();
            var prop = new PropertyDefinition("string", "MyProperty");
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithProperty(prop)
                .WithProperty(prop));
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_name_is_the_same_as_the_enclosing_type()
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithProperty(new PropertyDefinition("string", "MyClass")));
        }
    }
}
