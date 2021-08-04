using Microsoft.Extensions.Options;
using SchemaExplorer.Experimental;

namespace SchemaExplorer.SqlServer.Tests.Infrastructure
{
    public class SqlServerSchemaExplorerBuilder
    {
        public SqlServerSchemaExplorer Build()
        {
            return new(Options.Create(new SqlServerSchemaExplorerOptions
            {
                ConnectionString = "Server=.;Initial Catalog=SchemaExplorerTests;Persist Security Info=False;User Name=TestRunner;Password=TestRunner123;"
            }));
        }
    }
}
