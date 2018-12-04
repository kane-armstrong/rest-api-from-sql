using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Armsoft.RestApiFromSqlSchema.Components.Schema;

namespace Armsoft.RestApiFromSqlSchema
{
    public interface ISchemaExplorer
    {
        Task<IList<Table>> GetTablesAsync(CancellationToken cancellationToken);
    }
}