namespace RestApiFromSqlSchema.SqlServer.Internal
{
    internal class ColumnSchema
    {
        internal string TableCatalog { get; set; }
        internal string TableSchema { get; set; }
        internal string TableName { get; set; }
        internal string ColumnName { get; set; }
        internal int OrdinalPosition { get; set; }
        internal bool IsNullable { get; set; }
        internal string DataType { get; set; }
    }
}