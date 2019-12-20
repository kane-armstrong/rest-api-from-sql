using System.Collections.Generic;
using RestApiFromSqlSchema.Components.Schema;

namespace RestApiFromSqlSchema.Components.Templates
{
    public class ClassTemplate
    {
        public string Namespace { get; set; }
        public string TypeName { get; set; }
        public IList<Column> Properties { get; set; }
    }
}