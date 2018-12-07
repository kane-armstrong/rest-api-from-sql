using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Armsoft.RestApiFromSqlSchema.Components.Schema;
using Armsoft.RestApiFromSqlSchema.SqlServer.Internal;
using Armsoft.RestApiFromSqlSchema.SqlServer.Internal.Resources;
using Dapper;

namespace Armsoft.RestApiFromSqlSchema.SqlServer
{
    public class SqlServerSchemaExplorer : ISchemaExplorer
    {
        private readonly string _sqlServerConnectionString;

        public SqlServerSchemaExplorer(string sqlServerConnectionString)
        {
            _sqlServerConnectionString = sqlServerConnectionString;
        }

        private const string NullableSymbol = "?";

        public async Task<IList<Table>> GetTablesAsync(CancellationToken cancellationToken)
        {
            var columnSchema = await GetColumnSchemaOfAllTablesAsync(cancellationToken).ConfigureAwait(false);
            var constraints = (await GetConstraintsOfAllTablesAsync(cancellationToken).ConfigureAwait(false)).ToList();

            var schemas = columnSchema.GroupBy(x => x.TableSchema);

            return (from schema in schemas
                    select schema.Select(g => g).ToList()
                    into schemaColumns
                    where schemaColumns.Any()
                    let databaseName = schemaColumns.First().TableCatalog
                    let schemaName = schemaColumns.First().TableSchema
                    let columnSets = schemaColumns.GroupBy(x => x.TableName)
                    from columnSet in columnSets
                    where columnSet.Any()
                    let tableName = columnSet.First().TableName
                    let safeTableName = tableName.EscapeIllegalCsharpClassSymbols()
                    let columns = columnSet.Select(g => g)
                        .Select(x =>
                        {
                            var dataType = DataTypeMap.ContainsKey(x.DataType)
                                ? DataTypeMap[x.DataType]
                                : DefaultDataType;
                            if (x.IsNullable && !NonNullableDataTypes.Contains(dataType))
                            {
                                dataType += NullableSymbol;
                            }
                            var safePropertyName = ToLegalPropertyName(x.ColumnName, tableName).EscapeIllegalCsharpClassSymbols();
                            return new Column(new Name(x.ColumnName, safePropertyName), x.OrdinalPosition, x.IsNullable, dataType);
                        })
                        .ToList()
                    let tableConstraints = constraints.Where(x => x.ConstraintCatalog == databaseName && x.TableSchema == schemaName && x.TableName.ActualName == tableName)
                        .ToList()
                    select new Table(databaseName, schemaName, new Name(tableName, safeTableName), columns, tableConstraints)).ToList();
        }

        private async Task<IList<Constraint>> GetConstraintsOfAllTablesAsync(CancellationToken cancellationToken)
        {
            IEnumerable<TableConstraints> resultSet;
            using (var connection = new SqlConnection(_sqlServerConnectionString))
            {
                await connection.OpenAsync(cancellationToken);
                resultSet = await connection.QueryAsync<TableConstraints>(QueryContent.TableConstraintsQuery);
            }

            return resultSet
                .Select(item => new Constraint(
                    item.ConstraintCatalog,
                    item.TableSchema,
                    new Name(item.TableName, item.TableName.EscapeIllegalCsharpClassSymbols()),
                    new Name(item.ColumnName, item.ColumnName.EscapeIllegalCsharpClassSymbols()),
                    item.ConstraintName,
                    item.ConstraintType,
                    item.OrdinalPosition)
                ).ToList();
        }

        private async Task<IEnumerable<ColumnSchema>> GetColumnSchemaOfAllTablesAsync(CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_sqlServerConnectionString))
            {
                await connection.OpenAsync(cancellationToken);
                return await connection.QueryAsync<ColumnSchema>(QueryContent.ColumnSchemaQuery);
            }
        }

        private static string ToLegalPropertyName(string columnName, string tableName)
        {
            // Property names can't be the same as their enclosing type
            return columnName.Equals(tableName, StringComparison.InvariantCultureIgnoreCase)
                ? columnName + "1"
                : columnName;
        }

        private const string DefaultDataType = "object";

        private static readonly Dictionary<string, string> DataTypeMap = new Dictionary<string, string>
        {
            { "bigint", "long" },
            { "binary", "byte[]" },
            { "bit", "bool" },
            { "char", "string" },
            { "date", "DateTime" },
            { "datetime", "DateTime" },
            { "datetime2", "DateTime" },
            { "datetimeoffset", "DateTimeOffset" },
            { "decimal", "decimal" },
            { "float", "float" },
            { "image", "byte[]" },
            { "int", "int" },
            { "money", "decimal" },
            { "nchar", "string" },
            { "ntext", "string" },
            { "numeric", "decimal" },
            { "nvarchar", "string" },
            { "real", "double" },
            { "smalldatetime", "DateTime" },
            { "smallint", "short" },
            { "smallmoney", "decimal" },
            { "text", "string" },
            { "time", "TimeSpan" },
            { "timestamp", "byte[]" },
            { "tinyint", "byte" },
            { "uniqueidentifier", "Guid" },
            { "varbinary", "byte[]" },
            { "varchar", "string" },
            { "xml", "string" },
            { "hierarchyid", "string" },
            { "geography", "Point" }
        };

        internal static readonly List<string> NonNullableDataTypes = new List<string>
        {
            "string",
            "byte[]",
            "object",
            "Point"
        };
    }
}