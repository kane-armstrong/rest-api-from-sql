using CodeGenerator.Classes;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassSpec
{
    public class ConstructorTests
    {
        [Fact]
        public void A_single_constructor_is_added_correctly()
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            const string ctor = "public MyClass(string arg, int opt) : base(opt) { _arg = arg; }";
            sut.AddConstructor(ctor);
            sut.Constructors.Should().Contain(ctor);
        }

        [Fact]
        public void A_single_constructor_is_rendered_correctly()
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            const string ctor = "public MyClass(string arg, int opt) : base(opt) { _arg = arg; }";
            sut.AddConstructor(ctor);
            var result = sut.Render();
            result.Should().Contain(ctor);
        }

        [Fact]
        public void Multiple_constructors_are_added_correctly()
        {
            const string ctor1 = "public MyClass(string arg, int opt) : base(opt) { _arg = arg; }";
            const string ctor2 = "public MyClass(string arg) { _arg = arg; }";
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddConstructor(ctor1);
            sut.AddConstructor(ctor2);
            var result = sut.Render();
            result.Should().Contain(ctor1);
            result.Should().Contain(ctor2);
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_constructor_already_added()
        {
            const string ctor = "public MyClass(string arg) { _arg = arg; }";
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddConstructor(ctor);
            Assert.Throws<InvalidOperationException>(() => sut.AddConstructor(ctor));
        }

        [Theory]
        [InlineData(null)]
        public void An_argument_exception_is_thrown_when_constructor_is_invalid(string value)
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            Assert.Throws<ArgumentException>(() => sut.AddConstructor(value));
        }
    }
}
