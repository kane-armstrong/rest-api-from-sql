using CodeGenerator.Projects;
using FluentAssertions;
using System;
using Xunit;

namespace CodeGenerator.Tests.Projects.ProjectSpec
{
    public class PackageReferenceTests
    {
        [Fact]
        public void A_single_package_reference_without_a_version_is_added_correctly()
        {
            var sut = new ProjectBuilder().Build();
            var add = new PackageReference("Microsoft.AspNetCore.App");
            sut.AddPackageReference(add);
            sut.PackageReferences.Should().Contain(add);
        }

        [Fact]
        public void A_single_package_reference_with_a_version_is_added_correctly()
        {
            var sut = new ProjectBuilder().Build();
            var add = new PackageReference("Microsoft.EntityFrameworkCore", "5.0.0");
            sut.AddPackageReference(add);
            sut.PackageReferences.Should().Contain(add);
        }

        [Fact]
        public void A_single_package_reference_without_a_version_is_rendered_correctly()
        {
            var sut = new ProjectBuilder().Build();
            var add = new PackageReference("Microsoft.AspNetCore.App");
            sut.AddPackageReference(add);
            var result = sut.Render();
            result.Should().Contain($"<PackageReference Include=\"{add.Name}\" />");
        }

        [Fact]
        public void A_single_package_reference_with_a_version_is_rendered_correctly()
        {
            var sut = new ProjectBuilder().Build();
            var add = new PackageReference("Microsoft.EntityFrameworkCore", "5.0.0");
            sut.AddPackageReference(add);
            var result = sut.Render();
            result.Should().Contain($"<PackageReference Include=\"{add.Name}\" Version=\"{add.Version}\" />");
        }

        [Fact]
        public void Multiple_package_references_are_added_correctly()
        {
            var sut = new ProjectBuilder().Build();
            var add1 = new PackageReference("Microsoft.EntityFrameworkCore", "5.0.0");
            var add2 = new PackageReference("Microsoft.EntityFrameworkCore.SqlServer.NetTopologySuite", "5.0.0");
            sut.AddPackageReference(add1);
            sut.AddPackageReference(add2);
            sut.PackageReferences.Should().Contain(add1);
            sut.PackageReferences.Should().Contain(add2);
        }

        [Fact]
        public void An_invalid_operation_exception_is_thrown_when_adding_a_package_that_has_already_been_added()
        {
            var sut = new ProjectBuilder().Build();
            var add = new PackageReference("Microsoft.EntityFrameworkCore", "5.0.0");
            sut.AddPackageReference(add);
            Assert.Throws<InvalidOperationException>(() => sut.AddPackageReference(add));
        }

        [Fact]
        public void An_argument_null_exception_is_thrown_when_adding_a_package_reference_that_is_null()
        {
            var sut = new ProjectBuilder().Build();
            Assert.Throws<ArgumentNullException>(() => sut.AddPackageReference(null));
        }
    }
}
