using System;
using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassBuilderSpec
{
    public class ModifierTests
    {
        [Theory]
        [InlineData("abstract")]
        [InlineData("sealed")]
        [InlineData("static")]
        public void A_single_modifier_is_added_correctly(string value)
        {
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithModifier(value)
                .Build();
            result.Should().Contain($"{value} class MyClass");
        }

        [Fact]
        public void Multiple_modifiers_are_added_in_the_correct_order()
        {
            var sut = new ClassBuilder();
            const string mod1 = "abstract";
            const string mod2 = "sealed";
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithModifier(mod1)
                .WithModifier(mod2)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain($"public {mod1} {mod2} class");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("async")]
        [InlineData("const")]
        [InlineData("extern")]
        [InlineData("override")]
        [InlineData("readonly")]
        [InlineData("unsafe")]
        public void An_argument_exception_is_thrown_when_the_modifier_is_invalid(string value)
        {
            var sut = new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public);
            Assert.Throws<ArgumentException>(() => sut.WithModifier(value));
        }

        [Theory]
        [InlineData("static", "sealed")]
        [InlineData("sealed", "static")]
        [InlineData("static", "abstract")]
        [InlineData("abstract", "static")]
        public void An_invalid_operation_exception_is_thrown_for_invalid_modifier_combinations(string existing, string toAdd)
        {
            var sut = new ClassBuilder()
                .WithName("MyClass")
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithModifier(existing);
            Assert.Throws<InvalidOperationException>(() => sut.WithModifier(toAdd));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_the_modifier_has_already_been_added()
        {
            var sut = new ClassBuilder()
                .WithName("MyClass")
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithModifier("static");
            Assert.Throws<InvalidOperationException>(() => sut.WithModifier("static"));
        }
    }
}
