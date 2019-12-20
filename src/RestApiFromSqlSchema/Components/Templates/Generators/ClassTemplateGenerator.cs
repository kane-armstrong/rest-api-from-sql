using RestApiFromSqlSchema.Components.Schema;

namespace RestApiFromSqlSchema.Components.Templates.Generators
{
    public static class ClassTemplateGenerator
    {
        public static ClassTemplate Generate(Table table, string typeName)
        {
            return new ClassTemplate
            {
                Namespace = table.SchemaName,
                TypeName = typeName,
                Properties = table.Columns
            };
        }
    }
}