using System.Collections.Generic;

namespace SchemaExplorer.Experimental;

public class Schema
{
    public string Name { get; set; }
    public IEnumerable<Table> Tables { get; set; }
}