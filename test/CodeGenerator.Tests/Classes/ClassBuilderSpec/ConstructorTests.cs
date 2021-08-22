using System;
using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassBuilderSpec
{
    public class ConstructorTests
    {
        [Fact]
        public void A_single_constructor_is_added_correctly()
        {
            const string ctor = "public MyClass(string arg, int opt) : base(opt) { _arg = arg; }";
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithConstructor(ctor)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain(ctor);
        }

        [Fact]
        public void Multiple_constructors_are_added_correctly()
        {
            const string ctor1 = "public MyClass(string arg, int opt) : base(opt) { _arg = arg; }";
            const string ctor2 = "public MyClass(string arg) { _arg = arg; }";
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithConstructor(ctor1)
                .WithConstructor(ctor2)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain(ctor1);
            result.Should().Contain(ctor2);
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_constructor_already_added()
        {
            const string ctor = "public MyClass(string arg) { _arg = arg; }";
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .WithConstructor(ctor)
                .WithConstructor(ctor));
        }

        [Theory]
        [InlineData(null)]
        public void An_argument_exception_is_thrown_when_constructor_is_invalid(string value)
        {
            var sut = new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public);
            Assert.Throws<ArgumentException>(() => sut.WithConstructor(value));
        }
    }
}
