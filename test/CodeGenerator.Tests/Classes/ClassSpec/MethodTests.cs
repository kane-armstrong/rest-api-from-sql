using System;
using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassSpec;

public class MethodTests
{
    [Fact]
    public void A_single_method_is_added_correctly()
    {
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        var method = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
        sut.AddMethod(method);
        sut.Methods.Should().Contain(method);
    }

    [Fact]
    public void A_single_method_is_rendered_correctly()
    {
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        var method = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
        sut.AddMethod(method);
        var result = sut.Render();
        result.Should().Contain($"{method.Name}()");
    }

    [Fact]
    public void Multiple_methods_are_added_correctly()
    {
        var method1 = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
        var method2 = new Method(MethodAccessibilityLevel.Public, "void", "MyOtherMethod");
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        sut.AddMethod(method1);
        sut.AddMethod(method2);
        sut.Methods.Should().Contain(method1);
        sut.Methods.Should().Contain(method2);
    }

    [Fact]
    public void Methods_with_the_same_name_can_be_added_provided_their_signatures_are_different()
    {
        var method1 = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
        method1.AddArgument(new MethodArgument("int", "number"));
        var method2 = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
        method2.AddArgument(new MethodArgument("string", "numberAsText"));

        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        sut.AddMethod(method1);
        sut.AddMethod(method2);
        sut.Methods.Should().Contain(method1);
        sut.Methods.Should().Contain(method2);
    }

    [Fact]
    public void An_argument_null_exception_is_thrown_when_method_is_null()
    {
        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        Assert.Throws<ArgumentNullException>(() => sut.AddMethod(null));
    }

    [Fact]
    public void An_invalid_operation_exception_is_thrown_when_method_signature_conflicts_with_an_existing_method()
    {
        var method1 = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
        method1.AddArgument(new MethodArgument("int", "hello"));
        var method2 = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
        method2.AddArgument(new MethodArgument("int", "world"));

        var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
        sut.AddMethod(method1);
        Assert.Throws<InvalidOperationException>(() => sut.AddMethod(method2));
    }

    // todo abstract method in an non abstract class
}