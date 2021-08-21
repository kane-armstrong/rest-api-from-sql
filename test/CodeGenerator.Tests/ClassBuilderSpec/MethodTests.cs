using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class MethodTests
    {
        [Fact]
        public void A_single_method_is_added_correctly()
        {
            var method = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithMethod(method)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().NotBeEmpty();
        }

        [Fact]
        public void Multiple_methods_are_added_correctly()
        {
            var method1 = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
            var method2 = new Method(MethodAccessibilityLevel.Public, "void", "MyOtherMethod");

            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithMethod(method1)
                .WithMethod(method2)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain("void MyMethod()");
            result.Should().Contain("void MyOtherMethod()");
        }

        [Fact]
        public void Methods_with_the_same_name_can_be_added_provided_their_signatures_are_different()
        {
            var method1 = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
            method1.AddArgument(new MethodArgument("int", "number"));
            var method2 = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
            method2.AddArgument(new MethodArgument("string", "numberAsText"));

            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithMethod(method1)
                .WithMethod(method2)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain("void MyMethod(int number)");
            result.Should().Contain("void MyMethod(string numberAsText)");
        }

        [Fact]
        public void An_argument_null_exception_is_thrown_when_method_is_null()
        {
            var sut = new ClassBuilder();
            Assert.Throws<ArgumentNullException>(() => sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithMethod(null)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public));
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_method_signature_conflicts_with_an_existing_method()
        {
            var method1 = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
            method1.AddArgument(new MethodArgument("int", "number"));
            var method2 = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod");
            method2.AddArgument(new MethodArgument("int", "number"));

            var sut = new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithMethod(method1);
            Assert.Throws<InvalidOperationException>(() => sut.WithMethod(method2));
        }
    }
}
