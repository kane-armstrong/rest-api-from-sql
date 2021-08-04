using System.Threading;
using System.Threading.Tasks;

namespace SchemaExplorer.Experimental
{
    public interface ISchemaExplorer
    {
        Task<Database> ExploreDatabase(CancellationToken cancellationToken);
    }
}