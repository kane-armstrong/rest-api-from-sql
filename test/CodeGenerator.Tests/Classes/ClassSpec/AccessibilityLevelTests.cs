using System;
using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.ClassSpec
{
    public class AccessibilityLevelTests
    {
        [Theory]
        [InlineData(ClassAccessibilityLevel.Internal)]
        [InlineData(ClassAccessibilityLevel.Private)]
        [InlineData(ClassAccessibilityLevel.PrivateProtected)]
        [InlineData(ClassAccessibilityLevel.Protected)]
        [InlineData(ClassAccessibilityLevel.ProtectedInternal)]
        [InlineData(ClassAccessibilityLevel.Public)]
        public void Accessibility_level_is_set_correctly(ClassAccessibilityLevel level)
        {
            const string name = "TestClass";
            var sut = new Class("MyTestNamespace", level, name);
            sut.AccessibilityLevel.Should().Be(level);
        }

        [Theory]
        [InlineData(ClassAccessibilityLevel.Internal, "internal")]
        [InlineData(ClassAccessibilityLevel.Private, "private")]
        [InlineData(ClassAccessibilityLevel.PrivateProtected, "private protected")]
        [InlineData(ClassAccessibilityLevel.Protected, "protected")]
        [InlineData(ClassAccessibilityLevel.ProtectedInternal, "protected internal")]
        [InlineData(ClassAccessibilityLevel.Public, "public")]
        public void Accessibility_level_is_rendered_correctly(ClassAccessibilityLevel level, string expected)
        {
            const string name = "TestClass";
            var sut = new Class("MyTestNamespace", level, name);
            sut.Render().Should().Contain($"{expected} class {name}");
        }
    }
}
