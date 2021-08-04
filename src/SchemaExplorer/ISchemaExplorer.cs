using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SchemaExplorer
{
    public interface ISchemaExplorer
    {
        Task<IList<Table>> GetTablesAsync(CancellationToken cancellationToken);
    }
}