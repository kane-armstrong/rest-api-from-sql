using FluentAssertions;
using SchemaExplorer.SqlServer.Tests.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace SchemaExplorer.SqlServer.Tests.Experimental.SqlServerSchemaExplorerSpec
{
    public class TableTests
    {
        [Theory]
        [MemberData(nameof(ExpectedTableToColumnNameMappings))]
        public async Task Explorer_captures_table_columns_correctly(string schemaName, SchemaExplorer.Experimental.Table fixture)
        {
            var sut = new SqlServerSchemaExplorerBuilder().Build();
            var db = await sut.ExploreDatabase(CancellationToken.None);
            var table = db.Schema.First(x => x.Name == schemaName).Tables.First(x => x.Name == fixture.Name);
            table.Columns.Should().BeEquivalentTo(fixture.Columns);
        }

        public static IEnumerable<object[]> ExpectedTableToColumnNameMappings
        {
            get
            {
                yield return new object[]
                {
                    "dbo",
                    new SchemaExplorer.Experimental.Table
                    {
                        Name = "JoinWithMe",
                        Columns = new []
                        {
                            new SchemaExplorer.Experimental.Column
                            {
                                Name = "Id",
                                AllowsNulls = false,
                                DataType = "uniqueidentifier",
                                Order = 1
                            }
                        }
                    }
                };
            }
        }
    }
}
