using System;
using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassBuilderSpec
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
            const string className = "MyClass";
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName(className)
                .ImplementingInterface(value)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain($"class {className} : {value}");
        }

        [Fact]
        public void Multiple_interfaces_are_added_correctly()
        {
            var sut = new ClassBuilder();
            const string className = "MyClass";
            const string name1 = "IMyTestInterface";
            const string name2 = "IMyTestInterface2";
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .ImplementingInterface(name1)
                .ImplementingInterface(name2)
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .Build();
            result.Should().Contain($"class {className} : {name1}, {name2}");
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
            var sut = new ClassBuilder()
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass");
            Assert.Throws<ArgumentException>(() => sut.ImplementingInterface(value));
        }
    }
}
