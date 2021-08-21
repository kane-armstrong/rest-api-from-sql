using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.MethodSpec
{
    public class AccessibilityLevelTests
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
            var sut = new Method(level, "void", "TestMethod");
            var result = sut.Render();
            result.Should().Contain($"{expected} void TestMethod()");
        }
    }
}
