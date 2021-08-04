using System.Threading;
using System.Threading.Tasks;

namespace SchemaExplorer.Experimental
{
    public class SqlServerSchemaExplorer : ISchemaExplorer
    {
        private readonly SqlServerSchemaExplorerOptions _options;

        public SqlServerSchemaExplorer(SqlServerSchemaExplorerOptions options)
        {
            _options = options;
        }

        public Task<Database> ExploreDatabase(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}