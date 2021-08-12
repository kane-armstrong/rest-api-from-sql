using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.MethodDefinitionBuilderSpec
{
    public class WithAccessibilityLevelTests
    {
        [Theory]
        [InlineData(MethodAccessibilityLevel.Internal, "internal")]
        [InlineData(MethodAccessibilityLevel.Private, "private")]
        [InlineData(MethodAccessibilityLevel.PrivateProtected, "private protected")]
        [InlineData(MethodAccessibilityLevel.Protected, "protected")]
        [InlineData(MethodAccessibilityLevel.ProtectedInternal, "protected internal")]
        [InlineData(MethodAccessibilityLevel.Public, "public")]
        public void Builder_sets_accessibility_level_correctly(MethodAccessibilityLevel level, string expected)
        {
            var sut = new MethodDefinitionBuilder();
            var result = sut
                .WithReturnType("void")
                .WithName("TestMethod")
                .WithAccessibilityLevel(level)
                .Build();
            result.Should().Contain($"{expected} ");
        }

        [Fact]
        public void Builder_uses_most_recently_configured_accessibility_level()
        {
            const MethodAccessibilityLevel original = MethodAccessibilityLevel.Private;
            const MethodAccessibilityLevel expected = MethodAccessibilityLevel.Public;
            var sut = new MethodDefinitionBuilder();
            var result = sut
                .WithReturnType("void")
                .WithName("TestMethod")
                .WithAccessibilityLevel(original)
                .WithAccessibilityLevel(expected)
                .Build();
            result.Should().Contain("public void TestMethod");
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_accessibility_level_is_not_provided()
        {
            var sut = new MethodDefinitionBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithReturnType("void")
                .WithName("TestMethod")
                .Build());
        }
    }
}
