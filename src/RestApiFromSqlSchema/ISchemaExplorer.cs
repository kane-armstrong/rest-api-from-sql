using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestApiFromSqlSchema.Components.Schema;

namespace RestApiFromSqlSchema
{
    public interface ISchemaExplorer
    {
        Task<IList<Table>> GetTablesAsync(CancellationToken cancellationToken);
    }
}