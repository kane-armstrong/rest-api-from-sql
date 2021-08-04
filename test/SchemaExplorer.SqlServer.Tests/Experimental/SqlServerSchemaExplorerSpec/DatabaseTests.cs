using FluentAssertions;
using SchemaExplorer.SqlServer.Tests.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SchemaExplorer.SqlServer.Tests.Experimental.SqlServerSchemaExplorerSpec
{
    public class DatabaseTests
    {
        [Fact]
        public async Task Explorer_produces_the_correct_database_name()
        {
            const string databaseName = "SchemaExplorerTests";

            var sut = new SqlServerSchemaExplorerBuilder().Build();

            var db = await sut.ExploreDatabase(CancellationToken.None);
            db.Name.Should().Be(databaseName);
        }

        [Fact]
        public async Task Explorer_yields_the_expected_schema()
        {
            const string first = "dbo";
            const string second = "Demo";

            var sut = new SqlServerSchemaExplorerBuilder().Build();

            var db = await sut.ExploreDatabase(CancellationToken.None);
            db.Schema.Should().Contain(x => x.Name == first);
            db.Schema.Should().Contain(x => x.Name == second);
        }

        [Fact]
        public async Task Explorer_returns_the_correct_number_of_schema()
        {
            const int expectedSchemaCount = 2;

            var sut = new SqlServerSchemaExplorerBuilder().Build();

            var db = await sut.ExploreDatabase(CancellationToken.None);
            db.Schema.Count().Should().Be(expectedSchemaCount);
        }
    }
}
