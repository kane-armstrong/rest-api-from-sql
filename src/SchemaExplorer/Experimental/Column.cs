using System.Collections.Generic;

namespace SchemaExplorer.Experimental;

public class Column
{
    public string Name { get; set; }
    public int Order { get; set; }
    public bool AllowsNulls { get; set; }
    // TODO Enum?
    public string DataType { get; set; }
    public IEnumerable<Constraint> Constraints { get; set; }
}