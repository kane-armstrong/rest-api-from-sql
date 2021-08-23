using CodeGenerator.Classes;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassSpec
{
    public class InterfaceTests
    {
        [Theory]
        [InlineData("IMyTestInterface")]
        [InlineData("_IMyTestInterface")]
        [InlineData("MyTestInterface1")]
        [InlineData("_")]
        [InlineData("IMy_test_interface")]
        public void A_single_interface_is_added_correctly(string value)
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddInterface(value);
            sut.ImplementedInterfaces.Should().Contain(value);
        }

        [Theory]
        [InlineData("IMyTestInterface")]
        [InlineData("_IMyTestInterface")]
        [InlineData("MyTestInterface1")]
        [InlineData("_")]
        [InlineData("IMy_test_interface")]
        public void A_single_interface_is_rendered_correctly(string value)
        {
            const string className = "MyClass";
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            sut.AddInterface(value);
            var result = sut.Render();
            result.Should().Contain($"class {className} : {value}");
        }

        [Fact]
        public void Multiple_interfaces_are_added_correctly()
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            const string name1 = "IMyTestInterface";
            const string name2 = "IMyTestInterface2";
            sut.AddInterface(name1);
            sut.AddInterface(name2);
            sut.ImplementedInterfaces.Should().Contain(name1);
            sut.ImplementedInterfaces.Should().Contain(name2);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("123")]
        [InlineData(".")]
        [InlineData(".abc")]
        [InlineData("1abc")]
        [InlineData("An interface name")]
        [InlineData("MyTestInterface.TheThing")]
        public void An_argument_exception_is_thrown_when_interface_is_invalid(string value)
        {
            var sut = new Class("MyNamespace", ClassAccessibilityLevel.Public, "MyClass");
            Assert.Throws<ArgumentException>(() => sut.AddInterface(value));
        }
    }
}
