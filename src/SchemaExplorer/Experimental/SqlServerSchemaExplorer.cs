using Microsoft.Extensions.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SchemaExplorer.Experimental
{
    public class SqlServerSchemaExplorer : ISchemaExplorer
    {
        private readonly SqlServerSchemaExplorerOptions _options;

        public SqlServerSchemaExplorer(IOptions<SqlServerSchemaExplorerOptions> options)
        {
            _options = options?.Value ?? throw new ArgumentException("Options are required", nameof(options));
        }

        public Task<Database> ExploreDatabase(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}