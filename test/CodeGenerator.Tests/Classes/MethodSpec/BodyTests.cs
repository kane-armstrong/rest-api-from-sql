using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.MethodSpec;

public class BodyTests
{
    [Fact]
    public void Body_is_rendered_correctly()
    {
        const string body = "Console.WriteLine();";
        var method = new Method(MethodAccessibilityLevel.Public, "void", "MyMethod", body);
        method.Render().Should().Be($@"public void MyMethod()
{{
    {body}
}}");
    }

    [Fact]
    public void Method_renders_correctly_when_there_is_no_body()
    {
        const string returnType = "void";
        var method = new Method(MethodAccessibilityLevel.Public, returnType, "MyMethod");
        method.Render().Should().Be($@"public {returnType} MyMethod()
{{
}}");
    }
}