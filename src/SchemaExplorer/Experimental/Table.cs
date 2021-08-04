using System.Collections.Generic;

namespace SchemaExplorer.Experimental
{
    public class Table
    {
        public string Name { get; set; }
        public IEnumerable<Column> Columns { get; set; }
    }
}