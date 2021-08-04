﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Options;
using SchemaExplorer.Experimental;
using SchemaExplorer.SqlServer.Internal;
using SchemaExplorer.SqlServer.Internal.Resources;

namespace SchemaExplorer.SqlServer.Experimental
{
    public class SqlServerSchemaExplorer : SchemaExplorer.Experimental.ISchemaExplorer
    {
        private readonly SqlServerSchemaExplorerOptions _options;

        public SqlServerSchemaExplorer(IOptions<SqlServerSchemaExplorerOptions> options)
        {
            _options = options?.Value ?? throw new ArgumentException("Options are required", nameof(options));
        }

        public async Task<Database> ExploreDatabase(CancellationToken cancellationToken)
        {
            var metadata = await GetColumnSchemaOfAllTablesAsync(cancellationToken);
            var databaseName = metadata.First().TableCatalog;
            var schemaNames = metadata.Select(x => x.TableSchema).Distinct().ToList();
            
            var schemas = new List<Schema>();
            foreach (var schemaName in schemaNames)
            {
                var tableNames = metadata
                    .Where(x => x.TableSchema == schemaName)
                    .Select(x => x.TableName)
                    .Distinct()
                    .ToList();

                var tables = new List<SchemaExplorer.Experimental.Table>();
                foreach (var tableName in tableNames)
                {
                    var columns = metadata
                        .Where(x => x.TableSchema == schemaName && x.TableName == tableName)
                        .Select(x => new SchemaExplorer.Experimental.Column
                        {
                            AllowsNulls = x.IsNullable,
                            DataType = x.DataType,
                            Name = x.ColumnName,
                            Order = x.OrdinalPosition
                        });

                    tables.Add(new SchemaExplorer.Experimental.Table
                    {
                        Name = tableName,
                        Columns = columns
                    });
                }

                schemas.Add(new Schema
                {
                    Name = schemaName,
                    Tables = tables
                });
            }

            return new Database
            {
                Name = databaseName,
                Schema = schemas
            };
        }

        private async Task<List<TableConstraints>> GetConstraintsOfAllTablesAsync(CancellationToken cancellationToken)
        {
            await using var connection = new SqlConnection(_options.ConnectionString);
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
            var results = await connection.QueryAsync<TableConstraints>(QueryContent.TableConstraintsQuery).ConfigureAwait(false);
            return results.ToList();
        }

        private async Task<List<ColumnSchema>> GetColumnSchemaOfAllTablesAsync(CancellationToken cancellationToken)
        {
            await using var connection = new SqlConnection(_options.ConnectionString);
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
            var results = await connection.QueryAsync<ColumnSchema>(QueryContent.ColumnSchemaQuery).ConfigureAwait(false);
            return results.ToList();
        }
    }
}