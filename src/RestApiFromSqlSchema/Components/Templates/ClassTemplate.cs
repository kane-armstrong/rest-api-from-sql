using System.Collections.Generic;
using Armsoft.RestApiFromSqlSchema.Components.Schema;

namespace Armsoft.RestApiFromSqlSchema.Components.Templates
{
    public class ClassTemplate
    {
        public string Namespace { get; set; }
        public string TypeName { get; set; }
        public IList<Column> Properties { get; set; }
    }
}