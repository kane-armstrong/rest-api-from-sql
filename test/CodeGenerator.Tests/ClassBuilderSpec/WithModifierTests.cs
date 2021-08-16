using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class WithModifierTests
    {
        [Theory]
        [InlineData("abstract")]
        [InlineData("sealed")]
        [InlineData("static")]
        public void Builder_adds_a_single_modifier_correctly(string value)
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
        public void Builder_adds_multiple_modifiers_in_order()
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
        public void Builder_throws_argument_exception_for_invalid_modifiers(string value)
        {
            Assert.Throws<ArgumentException>(() => new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithModifier(value));
        }

        [Theory]
        [InlineData("static", "sealed")]
        [InlineData("sealed", "static")]
        [InlineData("static", "abstract")]
        [InlineData("abstract", "static")]
        public void Builder_throws_invalid_operation_exception_for_invalid_modifier_combinations(string existing, string toAdd)
        {
            var sut = new ClassBuilder()
                .WithName("MyClass")
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithModifier(existing);
            Assert.Throws<InvalidOperationException>(() => sut
                .WithModifier(toAdd));
        }
    }
}
