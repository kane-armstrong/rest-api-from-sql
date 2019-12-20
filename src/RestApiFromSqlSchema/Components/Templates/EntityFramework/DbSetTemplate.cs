using System.Collections.Generic;
using RestApiFromSqlSchema.Components.Schema;

namespace RestApiFromSqlSchema.Components.Templates.EntityFramework
{
    public class DbSetTemplate
    {
        public string Namespace { get; set; }
        public string TypeName { get; set; }
        public IList<Column> Keys { get; set; }
    }
}