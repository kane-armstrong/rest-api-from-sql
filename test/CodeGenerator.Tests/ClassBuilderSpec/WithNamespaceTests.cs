using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class WithNamespaceTests
    {
        // Sets namespace correctly
        // Uses the latest specified namespace
        // Throws appropriate exception for invalid namespaces
        // Throws appropriate exception when building without a namespace

        [Fact]
        public void Builder_sets_namespace_correctly()
        {
            var sut = new ClassBuilder();
            const string ns = "MyTestNamespace";
            var result = sut.WithNamespace(ns).Build();
            result.Should().Contain($"namespace {ns}");
        }

        [Fact]
        public void Builder_uses_most_recently_configured_namespace()
        {
            var sut = new ClassBuilder();
            const string ns1 = "MyTestNamespace";
            const string ns2 = "MyTestNamespace2";
            var result = sut.WithNamespace(ns1).WithNamespace(ns2).Build();
            result.Should().Contain($"namespace {ns2}");
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("123")]
        [InlineData(".")]
        [InlineData(".abc")]
        [InlineData("1abc")]
        public void Builder_throws_invalid_operation_exception_when_namespace_could_never_compile(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut.WithNamespace(value));
        }

        [Fact]
        public void Builder_throws_invalid_operation_exception_when_namespace_is_not_provided()
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut.Build());
        }
    }
}
