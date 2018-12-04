namespace Armsoft.RestApiFromSqlSchema.Components.Schema
{
    public class Constraint
    {
        public string ConstraintCatalog { get; }
        public string TableSchema { get; }
        public Name TableName { get; }
        public Name ColumnName { get; }
        public string ConstraintName { get; }
        public ConstraintType ConstraintType { get; }
        public int OrdinalPosition { get; }

        public Constraint(
            string constraintCatalog,
            string tableSchema,
            Name tableName,
            Name columnName,
            string constraintName,
            ConstraintType constraintType,
            int ordinalPosition)
        {
            ConstraintCatalog = constraintCatalog;
            TableSchema = tableSchema;
            TableName = tableName;
            ColumnName = columnName;
            ConstraintName = constraintName;
            ConstraintType = constraintType;
            OrdinalPosition = ordinalPosition;
        }
    }
}