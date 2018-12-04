using System.Collections.Generic;
using Armsoft.RestApiFromSqlSchema.Components.Schema;

namespace Armsoft.RestApiFromSqlSchema.Components.Templates.WebApi
{
    public class ListApiActionTemplate
    {
        public string Route { get; set; }
        public string RouteName { get; set; }
        public IList<Column> OrderByColumns { get; set; }
    }
}