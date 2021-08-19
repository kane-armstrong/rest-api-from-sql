using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.MethodSpec
{
    public class ArgumentTests
    {
        [Fact]
        public void A_single_argument_is_rendered_correctly()
        {
            var arg = new MethodArgument("int", "amount");
            var sut = new Method(MethodAccessibilityLevel.Public, "void", "TestMethod");
            sut.AddArgument(arg);
            sut.Render().Should().Contain($"public void TestMethod({arg.Type} {arg.Name})");
        }

        [Fact]
        public void Multiple_arguments_are_rendered_correctly()
        {
            var arg1 = new MethodArgument("int", "amount");
            var arg2 = new MethodArgument("Currency", "currency");
            var sut = new Method(MethodAccessibilityLevel.Public, "void", "TestMethod");
            sut.AddArgument(arg1);
            sut.AddArgument(arg2);
            sut.Arguments.Count.Should().Be(2);
            sut.Render().Should().Contain($"{arg1.Type} {arg1.Name}");
            sut.Render().Should().Contain($"{arg2.Type} {arg2.Name}");
        }

        [Fact]
        public void Multiple_arguments_are_rendered_in_the_correct_order()
        {
            var arg1 = new MethodArgument("int", "amount");
            var arg2 = new MethodArgument("Currency", "currency");
            var sut = new Method(MethodAccessibilityLevel.Public, "void", "TestMethod");
            sut.AddArgument(arg1);
            sut.AddArgument(arg2);
            sut.Render().Should().Contain($"TestMethod({arg1.Type} {arg1.Name}, {arg2.Type} {arg2.Name})");
        }

        [Fact]
        public void Method_renders_correctly_when_there_are_no_arguments()
        {
            var sut = new Method(MethodAccessibilityLevel.Public, "void", "TestMethod");
            sut.Render().Should().Contain("TestMethod()");
        }

        [Fact]
        public void Adding_an_argument_throws_an_argument_null_exception_when_argument_is_null()
        {
            var sut = new Method(MethodAccessibilityLevel.Public, "void", "TestMethod");
            Assert.Throws<ArgumentNullException>(() => sut.AddArgument(null));
        }

        [Fact]
        public void Adding_an_argument_throws_when_argument_is_already_added()
        {
            var sut = new Method(MethodAccessibilityLevel.Public, "void", "TestMethod");
            var arg = new MethodArgument("int", "number");
            sut.AddArgument(arg);
            Assert.Throws<InvalidOperationException>(() => sut.AddArgument(arg));
        }
    }
}
