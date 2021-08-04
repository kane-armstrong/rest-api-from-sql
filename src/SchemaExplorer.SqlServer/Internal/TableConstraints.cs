namespace SchemaExplorer.SqlServer.Internal
{
    internal class TableConstraints
    {
        internal string ConstraintCatalog { get; set; }
        internal string TableSchema { get; set; }
        internal string TableName { get; set; }
        internal string ColumnName { get; set; }
        internal string ConstraintName { get; set; }
        internal ConstraintType ConstraintType { get; set; }
        internal int OrdinalPosition { get; set; }
    }
}