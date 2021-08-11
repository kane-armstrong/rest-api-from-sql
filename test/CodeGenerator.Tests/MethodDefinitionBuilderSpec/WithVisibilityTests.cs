using System;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.MethodDefinitionBuilderSpec
{
    public class WithVisibilityTests
    {
        [Fact]
        public void Builder_sets_visibility_correctly()
        {
            const MethodVisibility expected = MethodVisibility.Private;
            var sut = new MethodDefinitionBuilder();
            var result = sut
                .WithReturnType("void")
                .WithName("TestMethod")
                .WithVisibility(expected)
                .Build();
            result.Should().Contain($"{expected.ToString().ToLowerInvariant()} ");
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_visibility_is_not_provided()
        {
            var sut = new MethodDefinitionBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithReturnType("void")
                .WithName("TestMethod")
                .Build());
        }
    }
}
