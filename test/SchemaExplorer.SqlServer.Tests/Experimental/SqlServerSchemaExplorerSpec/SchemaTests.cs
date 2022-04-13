using FluentAssertions;
using SchemaExplorer.SqlServer.Tests.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SchemaExplorer.SqlServer.Tests.Experimental.SqlServerSchemaExplorerSpec;

public class SchemaTests
{
    private const string DboSchemaName = "dbo";
    private const string DemoSchemaName = "Demo";

    [Fact]
    public async Task Explorer_produces_the_correct_schema_name_for_dbo()
    {
        var sut = new SqlServerSchemaExplorerBuilder().Build();

        var db = await sut.ExploreDatabase(CancellationToken.None);
        db.Schema.Should().Contain(x => x.Name == DboSchemaName);
    }

    [Theory]
    [InlineData("JoinWithMe")]
    [InlineData("WithCheckConstraint")]
    [InlineData("WithDefaultConstraint")]
    [InlineData("WithForeignKeyConstraint")]
    [InlineData("WithFourPrimaryKeys")]
    [InlineData("WithNoPrimaryKey")]
    [InlineData("WithOnePrimaryKey")]
    [InlineData("WithTwoPrimaryKeys")]
    [InlineData("WithUniqueConstraint")]
    [InlineData("NameThatAppearsInMultipleSchema")]
    public async Task Explorer_yields_the_expected_tables_for_dbo(string tableName)
    {
        var explorer = new SqlServerSchemaExplorerBuilder().Build();

        var db = await explorer.ExploreDatabase(CancellationToken.None);
        var sut = db.Schema.Single(x => x.Name == DboSchemaName);
        sut.Tables.Should().Contain(x => x.Name == tableName);
    }

    [Fact]
    public async Task Explorer_produces_the_correct_schema_name_for_Demo()
    {
        var sut = new SqlServerSchemaExplorerBuilder().Build();

        var db = await sut.ExploreDatabase(CancellationToken.None);
        db.Schema.Should().Contain(x => x.Name == DemoSchemaName);
    }

    [Theory]
    [InlineData("WithAllNotNullDataTypes")]
    [InlineData("WithAllNullDataTypes")]
    [InlineData("NameThatAppearsInMultipleSchema")]
    public async Task Explorer_yields_the_expected_tables_for_Demo(string tableName)
    {
        var explorer = new SqlServerSchemaExplorerBuilder().Build();

        var db = await explorer.ExploreDatabase(CancellationToken.None);
        var sut = db.Schema.Single(x => x.Name == DemoSchemaName);
        sut.Tables.Should().Contain(x => x.Name == tableName);
    }
}