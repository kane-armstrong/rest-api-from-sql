using System.Collections.Generic;

namespace Armsoft.RestApiFromSqlSchema.Components.Templates.EntityFramework
{
    public class DbContextTemplate
    {
        public string Namespace { get; set; }
        public string TypeName { get; set; }
        public IList<DbSetTemplate> DbSets { get; set; }
    }
}