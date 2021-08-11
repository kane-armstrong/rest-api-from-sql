using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.MethodDefinitionBuilderSpec
{
    public class WithAccessibilityLevelTests
    {
        [Fact]
        public void Builder_sets_accessibility_level_correctly()
        {
            const MethodAccessibilityLevel expected = MethodAccessibilityLevel.Private;
            var sut = new MethodDefinitionBuilder();
            var result = sut
                .WithReturnType("void")
                .WithName("TestMethod")
                .WithAccessibilityLevel(expected)
                .Build();
            result.Should().Contain($"{expected.ToString().ToLowerInvariant()} ");
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
            result.Should().Contain($"{expected.ToString().ToLowerInvariant()} ");
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
