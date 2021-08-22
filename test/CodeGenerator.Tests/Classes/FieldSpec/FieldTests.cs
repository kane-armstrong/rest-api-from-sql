using System;
using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.FieldSpec
{
    public class FieldTests
    {
        [Fact]
        public void Constructor_sets_type_correctly()
        {
            const string type = "int";
            var sut = new Field(type, "myField");
            sut.Type.Should().Be(type);
        }

        [Fact]
        public void Constructor_sets_name_correctly()
        {
            const string name = "myField";
            var sut = new Field("int", name);
            sut.Name.Should().Be(name);
        }

        [Fact]
        public void Constructor_sets_value_correctly()
        {
            const string value = " = 5;";
            var sut = new Field("int", "myField", value);
            sut.Value.Should().Be(value);
        }

        [Theory]
        [InlineData("new")]
        [InlineData("readonly")]
        [InlineData("static")]
        [InlineData("volatile")]
        public void Valid_modifiers_are_added_correctly(string value)
        {
            var sut = new Field("string", "myField");
            sut.AddModifier(value);
            sut.Modifiers.Should().Contain(value);
        }

        [Fact]
        public void Multiple_modifiers_are_added_correctly()
        {
            var sut = new Field("int", "myField", " = 5;");
            sut.AddModifier("static");
            sut.AddModifier("readonly");
            sut.Modifiers.Count.Should().Be(2);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("New")]
        [InlineData("STATIC")]
        public void Adding_an_invalid_modifier_throws_argument_exception(string value)
        {
            var sut = new Field("string", "myField");
            Assert.Throws<ArgumentException>(() => sut.AddModifier(value));
        }

        [Fact]
        public void Adding_const_modifier_works_when_field_does_have_a_value()
        {
            const string modifier = "const";
            var sut = new Field("int", "myField", " = 5;");
            sut.AddModifier(modifier);
            sut.Modifiers.Should().Contain(modifier);
        }

        [Fact]
        public void Adding_const_modifier_causes_invalid_operation_exception_when_field_does_not_have_a_value()
        {
            const string modifier = "const";
            var sut = new Field("int", "myField");
            Assert.Throws<InvalidOperationException>(() => sut.AddModifier(modifier));
        }

        [Fact]
        public void Adding_a_modifier_that_has_already_been_added_causes_an_invalid_operation_exception()
        {
            const string modifier = "static";
            var sut = new Field("int", "myField");
            sut.AddModifier(modifier);
            Assert.Throws<InvalidOperationException>(() => sut.AddModifier(modifier));
        }

        [Fact]
        public void Modifiers_are_optional()
        {
            var sut = new Field("string", "myField");
            sut.Modifiers.Should().BeEmpty();
        }
    }
}
