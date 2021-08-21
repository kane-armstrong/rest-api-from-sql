using System;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.PropertyDefinitionSpec
{
    public class PropertyDefinitionTests
    {
        [Fact]
        public void Constructor_sets_type_correctly()
        {
            const string type = "int";
            var sut = new PropertyDefinition(type, "MyProperty");
            sut.Type.Should().Be(type);
        }

        [Fact]
        public void Constructor_sets_name_correctly()
        {
            const string name = "MyProperty";
            var sut = new PropertyDefinition("int", name);
            sut.Name.Should().Be(name);
        }

        [Fact]
        public void Constructor_sets_value_correctly()
        {
            const string value = " => 5;";
            var sut = new PropertyDefinition("int", "MyProperty", value);
            sut.Value.Should().Be(value);
        }

        [Theory]
        [InlineData("abstract")]
        [InlineData("extern")]
        [InlineData("new")]
        [InlineData("override")]
        [InlineData("static")]
        [InlineData("virtual")]
        public void Valid_modifiers_are_added_correctly(string value)
        {
            var sut = new PropertyDefinition("string", "arg");
            sut.AddModifier(value);
            sut.Modifiers.Should().Contain(value);
        }

        [Fact]
        public void Multiple_modifiers_are_added_correctly()
        {
            var sut = new PropertyDefinition("int", "MyProperty");
            sut.AddModifier("static");
            sut.AddModifier("new");
            sut.Modifiers.Count.Should().Be(2);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("New")]
        [InlineData("STATIC")]
        public void Adding_an_invalid_modifier_throws_argument_exception(string value)
        {
            var sut = new PropertyDefinition("string", "MyProperty");
            Assert.Throws<ArgumentException>(() => sut.AddModifier(value));
        }
        
        [Fact]
        public void Adding_a_modifier_that_has_already_been_added_causes_an_invalid_operation_exception()
        {
            const string modifier = "static";
            var sut = new PropertyDefinition("int", "MyProperty");
            sut.AddModifier(modifier);
            Assert.Throws<InvalidOperationException>(() => sut.AddModifier(modifier));
        }

        [Fact]
        public void Adding_the_sealed_modifier_when_the_property_is_not_an_override_causes_invalid_operation_exception()
        {
            const string modifier = "sealed";
            var sut = new PropertyDefinition("int", "MyProperty");
            Assert.Throws<InvalidOperationException>(() => sut.AddModifier(modifier));
        }

        [Fact]
        public void Adding_the_sealed_modifier_works_when_the_property_is_an_override()
        {
            const string modifier = "sealed";
            var sut = new PropertyDefinition("int", "MyProperty");
            sut.AddModifier("override");
            sut.AddModifier(modifier);
            sut.Modifiers.Should().Contain(modifier);
        }

        [Fact]
        public void Modifiers_are_optional()
        {
            var sut = new PropertyDefinition("string", "MyProperty");
            sut.Modifiers.Should().BeEmpty();
        }

        [Fact]
        public void Adding_attributes_actually_works()
        {
            const string attr = "[Obsolete]";
            var sut = new PropertyDefinition("string", "MyProperty");
            sut.AddAttribute(attr);
            sut.Attributes.Should().Contain(attr);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Adding_an_invalid_attribute_throws_an_argument_exception(string value)
        {
            var sut = new PropertyDefinition("string", "MyProperty");
            Assert.Throws<ArgumentException>(() => sut.AddAttribute(value));
        }

        [Fact]
        public void Adding_an_attribute_that_has_already_been_added_throws_invalid_operation_exception()
        {
            const string attr = "[Obsolete]";
            var sut = new PropertyDefinition("string", "MyProperty");
            sut.AddAttribute(attr);
            Assert.Throws<InvalidOperationException>(() => sut.AddAttribute(attr));
        }
    }
}
