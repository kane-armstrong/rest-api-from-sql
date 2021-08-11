using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.MethodDefinitionBuilderSpec
{
    public class WithReturnTypeTests
    {
        [Fact]
        public void Builder_sets_return_type_correctly()
        {
            const string name = "TestMethod";
            const string returnType = "void";
            var sut = new MethodDefinitionBuilder();
            var result = sut
                .WithReturnType(returnType)
                .WithName(name)
                .WithVisibility(MethodVisibility.Private)
                .Build();
            result.Should().Contain($"{returnType} {name}");
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_return_type_is_not_provided()
        {
            var sut = new MethodDefinitionBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithName("TestMethod")
                .WithVisibility(MethodVisibility.Private)
                .Build());
        }
    }
}
