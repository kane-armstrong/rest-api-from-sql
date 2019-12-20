using System.Collections.Generic;
using System.Linq;
using RestApiFromSqlSchema.Components.Schema;
using RestApiFromSqlSchema.Components.Templates.EntityFramework;

namespace RestApiFromSqlSchema.Components.Templates.Generators
{
    public static class DbContextTemplateGenerator
    {
        public static DbContextTemplate Generate(IList<Table> tables, string dbContextNamespace, string dbContextTypeName)
        {
            return new DbContextTemplate
            {
                Namespace = dbContextNamespace,
                TypeName = dbContextTypeName,
                DbSets = tables.Select(table =>
                {
                    var keys = table.HasKeyColumn
                        ? new List<Column> { table.KeyColumn }
                        : table.CompositeKeyColumns.ToList();
                    return new DbSetTemplate
                    {
                        TypeName = table.Name.LegalCsharpName,
                        Namespace = table.SchemaName,
                        Keys = keys
                    };
                }).ToList()
            };
        }
    }
}