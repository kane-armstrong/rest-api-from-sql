using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class WithConstructorTests
    {
        [Fact]
        public void Builder_adds_constructor_correctly()
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
        public void Builder_adds_multiple_constructors_correctly()
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
        public void Builder_throws_invalid_operation_exception_when_constructor_already_added()
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
        public void Builder_throws_invalid_operation_exception_when_constructor_is_invalid(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithConstructor(value)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public));
        }
    }
}
