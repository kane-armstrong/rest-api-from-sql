using System;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.MethodBuilderSpec
{
    public class WithReturnTypeTests
    {
        [Fact]
        public void Builder_sets_return_type_correctly()
        {
            const string name = "TestMethod";
            const string returnType = "void";
            var sut = new MethodBuilder();
            var result = sut
                .WithReturnType(returnType)
                .WithName(name)
                .WithAccessibilityLevel(MethodAccessibilityLevel.Private)
                .Build();
            result.Should().Contain($"{returnType} {name}");
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_return_type_is_not_provided()
        {
            var sut = new MethodBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithName("TestMethod")
                .WithAccessibilityLevel(MethodAccessibilityLevel.Private)
                .Build());
        }
    }
}
