using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.MethodDefinitionBuilderSpec
{
    public class WithArgumentTests
    {
        [Fact]
        public void Builder_sets_one_argument_correctly()
        {
            var arg = new MethodArgument("int", "amount");
            var sut = new MethodDefinitionBuilder();
            var result = sut
                .WithReturnType("void")
                .WithName("MyMethod")
                .WithArgument(arg)
                .WithAccessibilityLevel(MethodAccessibilityLevel.Private)
                .Build();
            result.Should().Contain($"{arg.Type} {arg.Name}");
        }

        [Fact]
        public void Builder_sets_multiple_arguments_correctly()
        {
            var arg1 = new MethodArgument("int", "amount");
            var arg2 = new MethodArgument("string", "currency");
            var sut = new MethodDefinitionBuilder();
            var result = sut
                .WithReturnType("void")
                .WithName("MyMethod")
                .WithArgument(arg1)
                .WithArgument(arg2)
                .WithAccessibilityLevel(MethodAccessibilityLevel.Private)
                .Build();
            result.Should().Contain($"{arg1.Type} {arg1.Name}");
            result.Should().Contain($"{arg2.Type} {arg2.Name}");
        }

        [Fact]
        public void Builder_sets_arguments_in_order()
        {
            var arg1 = new MethodArgument("int", "amount");
            var arg2 = new MethodArgument("string", "currency");
            var sut = new MethodDefinitionBuilder();
            var result = sut
                .WithReturnType("void")
                .WithName("MyMethod")
                .WithArgument(arg1)
                .WithArgument(arg2)
                .WithAccessibilityLevel(MethodAccessibilityLevel.Private)
                .Build();
            result.Should().Contain($"{arg1.Type} {arg1.Name}, {arg2.Type} {arg2.Name}");
        }

        [Fact]
        public void Builder_works_when_no_arguments_are_provided()
        {
            const string name = "MyMethod";
            const string returnType = "void";
            var sut = new MethodDefinitionBuilder();
            var result = sut
                .WithReturnType(returnType)
                .WithName(name)
                .WithAccessibilityLevel(MethodAccessibilityLevel.Private)
                .Build();
            result.Should().Contain($"{returnType} {name}()");
        }
    }
}
