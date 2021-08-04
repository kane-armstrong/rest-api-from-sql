using SchemaExplorer;
using System.Collections.Generic;

namespace RestApiFromSqlSchema.Components.Templates.WebApi
{
    public class GetByIdApiActionTemplate
    {
        public string Route { get; set; }
        public string RouteName { get; set; }
        public IList<Column> FilterableColumns { get; set; }
    }
}