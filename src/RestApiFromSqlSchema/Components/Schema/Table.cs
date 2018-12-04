using System;
using System.Collections.Generic;
using System.Linq;

namespace Armsoft.RestApiFromSqlSchema.Components.Schema
{
    public class Table
    {
        public string DatabaseName { get; }
        public string SchemaName { get; }
        public Name Name { get; }
        public IList<Column> Columns { get; }
        public IList<Constraint> Constraints { get; }

        public bool HasKeyColumn => Constraints.Count(x => x.ConstraintType == ConstraintType.PrimaryKey) == 1;
        public Column KeyColumn => GetKeyColumn();
        public bool HasCompositeKey => Constraints.Count(x => x.ConstraintType == ConstraintType.PrimaryKey) > 1;
        public IEnumerable<Column> CompositeKeyColumns => GetKeyColumns();
        public bool HasUniqueKeys => Constraints.Any(x => x.ConstraintType == ConstraintType.Unique);

        private Column GetKeyColumn()
        {
            var keyColumns = Constraints.Where(x => x.ConstraintType == ConstraintType.PrimaryKey).ToList();
            return keyColumns.Count > 1
                ? null
                : Columns.FirstOrDefault(x => x.Name.ActualName.Equals(keyColumns.First().ColumnName.ActualName, StringComparison.InvariantCultureIgnoreCase));
        }

        private IEnumerable<Column> GetKeyColumns()
        {
            var keyColumns = Constraints.Where(x => x.ConstraintType == ConstraintType.PrimaryKey).ToList();
            foreach (var constraint in keyColumns)
            {
                if (constraint.ConstraintType == ConstraintType.PrimaryKey)
                {
                    yield return Columns.First(x => x.Name.ActualName.Equals(constraint.ColumnName.ActualName, StringComparison.InvariantCultureIgnoreCase));
                }
            }
        }

        public Table(string databaseName, string schemaName, Name name, IList<Column> columns, IList<Constraint> constraints)
        {
            DatabaseName = databaseName;
            SchemaName = schemaName;
            Name = name;
            Columns = columns;
            Constraints = constraints;
        }
    }
}