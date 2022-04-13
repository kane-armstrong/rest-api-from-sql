using CodeGenerator.Classes;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassSpec;

public class AttributeTests
{
    [Fact]
    public void A_single_attribute_is_added_correctly()
    {
        const string attribute = "[Table(\"SomeTableName\")]";
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        sut.AddAttribute(attribute);
        sut.Attributes.Should().Contain(attribute);
    }
        
    [Fact]
    public void A_single_attribute_is_rendered_correctly()
    {
        const string attribute = "[Table(\"SomeTableName\")]";
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        sut.AddAttribute(attribute);
        sut.Render().Should().Contain(attribute);
    }

    [Fact]
    public void Multiple_attributes_are_added_correctly()
    {
        const string attribute1 = "[Table(\"SomeTableName\")]";
        const string attribute2 = "[Serializable]";
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        sut.AddAttribute(attribute1);
        sut.AddAttribute(attribute2);
        sut.Attributes.Should().Contain(attribute1);
        sut.Attributes.Should().Contain(attribute2);
    }

    [Theory]
    [InlineData(null)]
    public void An_argument_exception_is_thrown_when_the_attribute_is_invalid(string value)
    {
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        Assert.Throws<ArgumentException>(() => sut.AddAttribute(value));
    }

    [Fact]
    public void An_invalid_operation_exception_is_thrown_when_the_attribute_has_already_been_added()
    {
        const string attribute = "[Table(\"SomeTableName\")]";
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        sut.AddAttribute(attribute);
        Assert.Throws<InvalidOperationException>(() => sut.AddAttribute(attribute));
    }
}