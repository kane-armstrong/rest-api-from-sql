using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.ClassBuilderSpec
{
    public class WithMethodDefinitionTests
    {
        [Fact]
        public void Builder_adds_method_correctly()
        {
            const string methodBody = "wouldnt_compile_but_that_doesnt_matter_for_this_test";
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithMethod(methodBody)
                .Build();
            result.Should().Contain(methodBody);
        }

        [Fact]
        public void Builder_adds_multiple_methods_correctly()
        {
            const string methodBody1 = "wouldnt_compile_but_that_doesnt_matter_for_this_test";
            const string methodBody2 = "wouldnt_compile_but_that_doesnt_matter_for_this_test2";
            var sut = new ClassBuilder();
            var result = sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithMethod(methodBody1)
                .WithMethod(methodBody2)
                .Build();
            result.Should().Contain(methodBody1);
            result.Should().Contain(methodBody2);
        }

        [Theory]
        [InlineData(null)]
        public void Builder_throws_invalid_operation_exception_when_method_body_is_invalid(string value)
        {
            var sut = new ClassBuilder();
            Assert.Throws<InvalidOperationException>(() => sut
                .WithNamespace("MyNamespace")
                .WithName("MyClass")
                .WithMethod(value));
        }
    }
}
