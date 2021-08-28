using CodeGenerator.Projects;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Projects.ProjectSpec
{
    public class ProjectTests
    {
        [Fact]
        public void Fully_configured_projects_are_rendered_in_the_correct_format()
        {
            var sut = new ProjectBuilder().WithName("MyProject").WithTargetFramework("net5.0").Build();
            sut.AddPackageReference(new PackageReference("Microsoft.AspNetCore.App"));
            sut.AddPackageReference(new PackageReference("Microsoft.EntityFrameworkCore", "5.0.0"));
            sut.AddPackageReference(new PackageReference("Newtonsoft.Json", "12.0.3"));
            sut.AddPackageReference(new PackageReference("FluentValidation", "9.3.0"));
            sut.AddPackageReference(new PackageReference("FluentValidation.AspNetCore", "9.3.0"));
            var result = sut.Render();
            result.Should().Be(@"<Project Sdk=""Microsoft.NET.Sdk.Web"">

  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include=""Microsoft.AspNetCore.App"" />
    <PackageReference Include=""Microsoft.EntityFrameworkCore"" Version=""5.0.0"" />
    <PackageReference Include=""Newtonsoft.Json"" Version=""12.0.3"" />
    <PackageReference Include=""FluentValidation"" Version=""9.3.0"" />
    <PackageReference Include=""FluentValidation.AspNetCore"" Version=""9.3.0"" />
  </ItemGroup>
</Project>");
        }

        [Fact]
        public void Minimally_configured_projects_are_rendered_in_the_correct_format()
        {
            var sut = new ProjectBuilder().WithName("MyProject").WithTargetFramework("net5.0").Build();
            var result = sut.Render();
            result.Should().Be(@"<Project Sdk=""Microsoft.NET.Sdk.Web"">

  <PropertyGroup>
    <TargetFramework>net5.0</TargetFramework>
  </PropertyGroup>
</Project>");
        }
    }
}
