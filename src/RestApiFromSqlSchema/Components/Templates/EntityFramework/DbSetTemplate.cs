using System.Collections.Generic;
using Armsoft.RestApiFromSqlSchema.Components.Schema;

namespace Armsoft.RestApiFromSqlSchema.Components.Templates.EntityFramework
{
    public class DbSetTemplate
    {
        public string Namespace { get; set; }
        public string TypeName { get; set; }
        public IList<Column> Keys { get; set; }
    }
}