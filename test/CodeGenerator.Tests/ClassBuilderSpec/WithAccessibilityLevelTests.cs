using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class WithAccessibilityLevelTests
    {
        [Theory]
        [InlineData(ClassAccessibilityLevel.Internal, "internal")]
        [InlineData(ClassAccessibilityLevel.Private, "private")]
        [InlineData(ClassAccessibilityLevel.PrivateProtected, "private protected")]
        [InlineData(ClassAccessibilityLevel.Protected, "protected")]
        [InlineData(ClassAccessibilityLevel.ProtectedInternal, "protected internal")]
        [InlineData(ClassAccessibilityLevel.Public, "public")]
        public void Builder_sets_accessibility_level_correctly(ClassAccessibilityLevel level, string expected)
        {
            const string name = "TestClass";
            var sut = new ClassBuilder();
            var result = sut
                .WithName(name)
                .WithNamespace("MyTestNamespace")
                .WithAccessibilityLevel(level)
                .Build();
            result.Should().Contain($"{expected} class {name}");
        }

        [Fact]
        public void Builder_uses_most_recently_configured_accessibility_level()
        {
            const ClassAccessibilityLevel original = ClassAccessibilityLevel.Private;
            const ClassAccessibilityLevel expected = ClassAccessibilityLevel.Public;
            const string name = "TestClass";
            var sut = new ClassBuilder();
            var result = sut
                .WithName(name)
                .WithNamespace("MyTestNamespace")
                .WithAccessibilityLevel(original)
                .WithAccessibilityLevel(expected)
                .Build();
            result.Should().Contain($"{expected.ToString().ToLowerInvariant()} class {name}");
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_accessibility_level_is_not_provided()
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyTestNamespace")
                .WithName("TestMethod")
                .Build());
        }
    }
}
