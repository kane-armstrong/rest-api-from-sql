using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.MethodSpec
{
    public class ModifierTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("const")]
        [InlineData("event")]
        [InlineData("extern")]
        [InlineData("in")]
        [InlineData("out")]
        [InlineData("readonly")]
        [InlineData("unsafe")]
        [InlineData("volatile")]
        public void Adding_a_modifier_throws_argument_exception_when_modifier_is_invalid(string value)
        {
            var method = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
            Assert.Throws<ArgumentException>(() => method.AddModifier(value));
        }

        [Fact]
        public void Adding_a_modifier_throws_invalid_operation_exception_when_marking_abstract_with_a_body()
        {
            var method = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod", "Console.WriteLine();");
            Assert.Throws<InvalidOperationException>(() => method.AddModifier("abstract"));
        }

        [Fact]
        public void Adding_a_modifier_throws_invalid_operation_exception_when_marking_sealed_when_not_override()
        {
            var method = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
            Assert.Throws<InvalidOperationException>(() => method.AddModifier("sealed"));
        }

        [Fact]
        public void Marking_method_as_sealed_works_if_method_is_marked_as_override()
        {
            var method = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
            method.AddModifier("override");
            method.AddModifier("sealed");
            method.Modifiers.Count.Should().Be(2);
            method.Render().Should().Contain("override sealed");
        }

        [Theory]
        [InlineData("async")]
        [InlineData("new")]
        [InlineData("override")]
        [InlineData("static")]
        [InlineData("virtual")]
        public void A_single_modifier_is_rendered_correctly(string value)
        {
            var method = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
            method.AddModifier(value);
            method.Render().Should().Contain($"public {value} void MyMethod");
        }

        [Fact]
        public void Modifiers_are_rendered_in_the_order_they_were_added()
        {
            var method = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
            method.AddModifier("static");
            method.AddModifier("async");
            method.Render().Should().Contain("public static async void MyMethod");
        }

        [Fact]
        public void Abstract_methods_are_rendered_in_the_correct_format()
        {
            var method = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
            method.AddModifier("abstract");
            method.Render().Should().Be("public abstract void MyMethod();");
        }
    }
}
