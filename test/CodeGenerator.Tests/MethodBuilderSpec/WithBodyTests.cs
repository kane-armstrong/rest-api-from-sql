using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.MethodBuilderSpec
{
    public class WithBodyTests
    {
        [Fact]
        public void Builder_sets_body_correctly()
        {
            const string returnType = "void";
            const string name = "MyMethod";
            const string body = "Console.WriteLine(\"comedy\")";
            var sut = new MethodBuilder();
            var result = sut
                .WithReturnType(returnType)
                .WithName(name)
                .WithBody(body)
                .WithAccessibilityLevel(MethodAccessibilityLevel.Private)
                .Build();
            result.Should().Contain(body);
        }

        [Fact]
        public void Builder_works_when_body_is_not_provided()
        {
            const string body = "Console.WriteLine(\"comedy\")";
            var sut = new MethodBuilder();
            var result = sut
                .WithName("MyMethod")
                .WithReturnType("void")
                .WithAccessibilityLevel(MethodAccessibilityLevel.Private)
                .Build();
            result.Should().NotContain(body);
        }
    }
}
