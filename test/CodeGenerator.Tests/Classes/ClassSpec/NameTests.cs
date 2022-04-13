using CodeGenerator.Classes;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassSpec;

public class NameTests
{
    [Theory]
    [InlineData("MyTestClass")]
    [InlineData("_MyTestClass")]
    [InlineData("MyTestClass1")]
    [InlineData("_")]
    [InlineData("My_test_class")]
    public void Class_name_is_set_correctly(string value)
    {
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, value);
        sut.ClassName.Should().Be(value);
    }

    [Theory]
    [InlineData("MyTestClass")]
    [InlineData("_MyTestClass")]
    [InlineData("MyTestClass1")]
    [InlineData("_")]
    [InlineData("My_test_class")]
    public void Class_name_is_rendered_correctly(string value)
    {
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, value);
        var result = sut.Render();
        result.Should().Contain($"class {value}");
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    [InlineData("123")]
    [InlineData(".")]
    [InlineData(".abc")]
    [InlineData("1abc")]
    [InlineData("A class name")]
    [InlineData("MyTestNamespace.TheThing")]
    public void An_argument_exception_is_thrown_when_the_class_name_is_invalid(string value)
    {
        Assert.Throws<ArgumentException>(() => new Class("MyNamespace", ClassAccessibilityLevel.Public, value));
    }
}