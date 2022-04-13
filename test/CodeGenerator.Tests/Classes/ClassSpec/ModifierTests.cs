using CodeGenerator.Classes;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassSpec;

public class ModifierTests
{
    [Theory]
    [InlineData("abstract")]
    [InlineData("sealed")]
    [InlineData("static")]
    public void A_single_modifier_is_added_correctly(string value)
    {
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        sut.AddModifier(value);
        sut.Modifiers.Should().Contain(value);
    }

    [Theory]
    [InlineData("abstract")]
    [InlineData("sealed")]
    [InlineData("static")]
    public void A_single_modifier_is_rendered_correctly(string value)
    {
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        sut.AddModifier(value);
        var result = sut.Render();
        result.Should().Contain($"{value} class MyClass");
    }

    [Fact]
    public void Multiple_modifiers_are_rendered_in_the_correct_order()
    {
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        const string mod1 = "abstract";
        const string mod2 = "sealed";
        sut.AddModifier(mod1);
        sut.AddModifier(mod2);
        var result = sut.Render();
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
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        Assert.Throws<ArgumentException>(() => sut.AddModifier(value));
    }

    [Theory]
    [InlineData("static", "sealed")]
    [InlineData("sealed", "static")]
    [InlineData("static", "abstract")]
    [InlineData("abstract", "static")]
    public void An_invalid_operation_exception_is_thrown_for_invalid_modifier_combinations(string existing, string toAdd)
    {
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        sut.AddModifier(existing);
        Assert.Throws<InvalidOperationException>(() => sut.AddModifier(toAdd));
    }

    [Fact]
    public void An_invalid_operation_exception_is_thrown_when_the_modifier_has_already_been_added()
    {
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        sut.AddModifier("static");
        Assert.Throws<InvalidOperationException>(() => sut.AddModifier("static"));
    }
}