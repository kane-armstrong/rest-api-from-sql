using System;
using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.MethodArgumentSpec
{
    public class MethodArgumentTests
    {
        [Fact]
        public void Constructor_sets_type_correctly()
        {
            const string type = "void";
            var sut = new MethodArgument(type, "arg");
            sut.Type.Should().Be(type);
        }

        [Fact]
        public void Constructor_sets_name_correctly()
        {
            const string name = "arg";
            var sut = new MethodArgument("void", name);
            sut.Name.Should().Be(name);
        }

        [Theory]
        [InlineData("ref")]
        [InlineData("out")]
        [InlineData("params")]
        [InlineData("in")]
        public void Constructor_sets_modifier_correctly(string value)
        {
            var sut = new MethodArgument("string", "arg", value);
            sut.Modifier.Should().Be(value);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Ref")]
        [InlineData("OUT")]
        [InlineData("Params")]
        [InlineData("iN")]
        public void Constructor_throws_argument_exception_for_invalid_modifiers(string value)
        {
            Assert.Throws<ArgumentException>(() => new MethodArgument("string", "arg", value));
        }

        [Fact]
        public void Modifier_is_optional()
        {
            var sut = new MethodArgument("string", "arg");
            sut.Modifier.Should().BeNull();
        }

        [Fact]
        public void Adding_attributes_actually_works()
        {
            const string attr = "[FromBody]";
            var sut = new MethodArgument("string", "arg");
            sut.AddAttribute(attr);
            sut.Attributes.Should().Contain(attr);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Adding_an_invalid_attribute_throws_an_argument_exception(string value)
        {
            var sut = new MethodArgument("string", "arg");
            Assert.Throws<ArgumentException>(() => sut.AddAttribute(value));
        }

        [Fact]
        public void Adding_an_attribute_that_has_already_been_added_throws_invalid_operation_exception()
        {
            const string attr = "[FromBody]";
            var sut = new MethodArgument("string", "arg");
            sut.AddAttribute(attr);
            Assert.Throws<InvalidOperationException>(() => sut.AddAttribute(attr));
        }
    }
}
