using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.MethodSpec;

public class ReturnTypeTests
{
    [Fact]
    public void Return_type_is_rendered_correctly()
    {
        const string returnType = "void";
        var method = new Method(MethodAccessibilityLevel.Public, returnType, "MyMethod");
        method.Render().Should().Contain($"public {returnType} MyMethod()");
    }
}