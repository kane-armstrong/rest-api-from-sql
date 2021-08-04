using SchemaExplorer;
using System.Collections.Generic;

namespace RestApiFromSqlSchema.Components.Templates.WebApi
{
    public class EditApiActionTemplate
    {
        public string Route { get; set; }
        public string RouteName { get; set; }
        public IList<Column> FilterableColumns { get; set; }
        public IList<Column> EditableColumns { get; set; }
        public IList<Column> KeyColumns { get; set; }

        /// <summary>
        ///     Gets or sets the name of the variable that is retrieved from the database
        /// </summary>
        public string ExistingEntityVariableName { get; set; } = "existing";

        /// <summary>
        ///     Gets or sets the name of the variable that is passed through in the action method arguments
        /// </summary>
        public string ModelVariableName { get; set; } = "value";
    }
}