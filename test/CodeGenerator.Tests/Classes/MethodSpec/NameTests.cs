using CodeGenerator.Classes;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Classes.MethodSpec;

public class NameTests
{
    [Fact]
    public void Name_is_rendered_correctly()
    {
        const string name = "MyMethod";
        var method = new Method(MethodAccessibilityLevel.Public, "void", name);
        method.Render().Should().Contain($"public void {name}()");
    }
}