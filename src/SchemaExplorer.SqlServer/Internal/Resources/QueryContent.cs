using System.Reflection;
using Pedantic.IO;

namespace SchemaExplorer.SqlServer.Internal.Resources
{
    internal static class QueryContent
    {
        private static Assembly Assembly => typeof(QueryContent).Assembly;
        private static string Namespace => typeof(QueryContent).Namespace;

        internal static string ColumnSchemaQuery => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.GetColumnSchema.sql");
        internal static string TableConstraintsQuery => EmbeddedResource.ReadAllText(Assembly, $"{Namespace}.GetTableConstraints.sql");
    }
}