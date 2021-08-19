using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.MethodSpec
{
    public class AttributeTests
    {
        [Fact]
        public void A_single_attribute_is_rendered_correctly()
        {
            const string attr = "[Obsolete]";
            var sut = new Method(MethodAccessibilityLevel.Public, "void", "TestMethod");
            sut.AddAttribute(attr);
            sut.Render().Should().Contain(attr);
        }

        [Fact]
        public void Multiple_attributes_are_rendered_in_the_correct_order()
        {
            var arg1 = "[Theory]";
            var arg2 = "[InlineData(\"test\")]";
            var sut = new Method(MethodAccessibilityLevel.Public, "void", "TestMethod");
            sut.AddAttribute(arg1);
            sut.AddAttribute(arg2);
            sut.Attributes.Count.Should().Be(2);
            sut.Render().Should().Be(@$"{arg1}
{arg2}
public void TestMethod()
{{
}}");
        }

        [Fact]
        public void Method_renders_correctly_when_there_are_no_attributes()
        {
            var sut = new Method(MethodAccessibilityLevel.Public, "void", "TestMethod");
            sut.Render().Should().Contain("TestMethod()");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Adding_an_attribute_throws_an_attribute_exception_when_attribute_is_invalid(string value)
        {
            var sut = new Method(MethodAccessibilityLevel.Public, "void", "TestMethod");
            Assert.Throws<ArgumentException>(() => sut.AddAttribute(value));
        }

        [Fact]
        public void Adding_an_attribute_throws_invalid_operation_exception_when_attribute_is_already_added()
        {
            const string attr = "[Fact]";
            var sut = new Method(MethodAccessibilityLevel.Public, "void", "TestMethod");
            sut.AddAttribute(attr);
            Assert.Throws<InvalidOperationException>(() => sut.AddAttribute(attr));
        }
    }
}
