using System.Collections.Generic;
using Armsoft.RestApiFromSqlSchema.Components.Schema;

namespace Armsoft.RestApiFromSqlSchema.Components.Templates.WebApi
{
    public class GetByIdApiActionTemplate
    {
        public string Route { get; set; }
        public string RouteName { get; set; }
        public IList<Column> FilterableColumns { get; set; }
    }
}