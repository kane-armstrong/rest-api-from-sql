using System.Collections.Generic;

namespace SchemaExplorer.Experimental
{
    public class Database
    {
        public string Name { get; set; }
        public IEnumerable<Schema> Schema { get; set; }
    }
}
