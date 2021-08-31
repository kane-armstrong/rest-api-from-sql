using CodeGenerator.Projects;
using CodeGenerator.Solutions;
using FluentAssertions;
using Xunit;

namespace CodeGenerator.Tests.Solutions.SolutionSpec
{
    public class IdTests
    {
        [Fact]
        public void An_id_is_generated_when_creating_a_solution()
        {
            var sut = new Solution(@"C:\test", "MySolution");
            sut.Id.Should().NotBeEmpty();
        }
    }
}
