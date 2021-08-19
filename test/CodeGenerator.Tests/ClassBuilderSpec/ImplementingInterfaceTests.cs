using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class ImplementingInterfaceTests
    {
        [Theory]
        [InlineData("IMyTestInterface")]
        [InlineData("_IMyTestInterface")]
        [InlineData("MyTestInterface1")]
        [InlineData("_")]
        [InlineData("IMy_test_interface")]
        public void Builder_adds_a_single_implemented_interface_correctly(string value)
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
        public void Builder_adds_multiple_implemented_interface_correctly()
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
        public void Builder_throws_argument_exception_when_interface_name_could_never_compile(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<ArgumentException>(() => sut
                .WithNamespace("MyNamespace")
                .WithAccessibilityLevel(ClassAccessibilityLevel.Public)
                .WithName("MyClass")
                .ImplementingInterface(value));
        }
    }
}
