using System.Collections.Generic;
using System.Linq;
using Armsoft.RestApiFromSqlSchema.Components.Schema;
using Armsoft.RestApiFromSqlSchema.Components.Templates.WebApi;
using Armsoft.RestApiFromSqlSchema.Extensions;

namespace Armsoft.RestApiFromSqlSchema.Components.Templates.Generators
{
    public class ApiControllerTemplateGenerator
    {
        public ApiControllerTemplate Generate(Table table)
        {
            var config = new ApiControllerTemplate
            {
                Namespace = table.SchemaName,
                TypeName = table.Name.LegalCsharpName,
                IncludeUniqueKeyActions = table.HasUniqueKeys,
                GetByUniqueKeyTemplates = new List<GetByIdApiActionTemplate>(),
                EditByUniqueKeyTemplates = new List<EditApiActionTemplate>(),
                DeleteByUniqueKeyTemplates = new List<DeleteApiActionTemplate>(),
                ListApiActionTemplate = ConfigureListApiActionTemplate(table),
                GetByIdApiActionTemplate = ConfigureGetByIdApiActionTemplate(table),
                CreateApiActionTemplate = ConfigureCreateApiActionTemplate(table),
                EditApiActionTemplate = ConfigureEditApiActionTemplate(table),
                DeleteApiActionTemplate = ConfigureDeleteApiActionTemplate(table)
            };

            if (table.HasUniqueKeys)
            {
                var uniqueKeyGroups = table.Constraints.Where(x => x.ConstraintType == ConstraintType.Unique).ToList().GroupBy(x => x.ConstraintName);

                foreach (var group in uniqueKeyGroups)
                {
                    config.GetByUniqueKeyTemplates.Add(ConfigureGetByUniqueKeyTemplate(table, group));
                    config.EditByUniqueKeyTemplates.Add(ConfigureEditByUniqueKeyTemplate(table, group));
                    config.DeleteByUniqueKeyTemplates.Add(ConfigureDeleteByUniqueKeyTemplate(table, group));
                }
            }

            return config;
        }

        private GetByIdApiActionTemplate ConfigureGetByUniqueKeyTemplate(Table table, IGrouping<string, Constraint> group)
        {
            var columns = table.Columns.Where(x => group.Select(y => y).Any(z => z.ColumnName.ActualName == x.ActualName)).ToList();
            return new GetByIdApiActionTemplate
            {
                Route = string.Join("_", group.Select(x => x).Select(x => x.ColumnName.ActualName)),
                RouteName = $"Get_{table.SchemaName}_{table.Name.ActualName}_By_{string.Join("_", group.Select(x => x.ColumnName.ActualName))}",
                FilterableColumns = columns
            };
        }

        private EditApiActionTemplate ConfigureEditByUniqueKeyTemplate(Table table, IGrouping<string, Constraint> group)
        {
            var filterableColumns = table.Columns.Where(x => group.Select(y => y).Any(z => z.ColumnName.ActualName == x.ActualName)).ToList();
            return new EditApiActionTemplate
            {
                Route = string.Join("_", group.Select(x => x).Select(x => x.ColumnName.ActualName)),
                RouteName = $"Edit_{table.SchemaName}_{table.Name.ActualName}_By_{string.Join("_", group.Select(x => x.ColumnName.ActualName))}",
                FilterableColumns = filterableColumns,
                EditableColumns = table.Columns
            };
        }

        private DeleteApiActionTemplate ConfigureDeleteByUniqueKeyTemplate(Table table, IGrouping<string, Constraint> group)
        {
            var filterableColumns = table.Columns.Where(x => group.Select(y => y).Any(z => z.ColumnName.ActualName == x.ActualName)).ToList();
            return new DeleteApiActionTemplate
            {
                Route = string.Join("_", group.Select(x => x).Select(x => x.ColumnName.ActualName)),
                RouteName = $"Delete_{table.SchemaName}_{table.Name.ActualName}_By_{string.Join("_", group.Select(x => x.ColumnName.ActualName))}",
                FilterableColumns = filterableColumns
            };
        }

        private ListApiActionTemplate ConfigureListApiActionTemplate(Table table)
        {
            var orderByColumns = new List<Column>();
            if (table.HasKeyColumn)
            {
                orderByColumns.Add(table.KeyColumn);
            }

            if (table.HasCompositeKey)
            {
                orderByColumns.AddRange(table.CompositeKeyColumns);
            }

            return new ListApiActionTemplate
            {
                Route = "",
                RouteName = $"List_{table.SchemaName}_{table.Name.ActualName}",
                OrderByColumns = orderByColumns
            };
        }

        private GetByIdApiActionTemplate ConfigureGetByIdApiActionTemplate(Table table)
        {
            return new GetByIdApiActionTemplate
            {
                Route = GenerateActionRoute(table),
                RouteName = $"GetById_{table.SchemaName}_{table.Name.ActualName}",
                FilterableColumns = FindFilterableColumns(table)
            };
        }

        private CreateApiActionTemplate ConfigureCreateApiActionTemplate(Table table)
        {
            return new CreateApiActionTemplate
            {
                Route = "",
                RouteName = $"Create_{table.SchemaName}_{table.Name.ActualName}"
            };
        }

        private EditApiActionTemplate ConfigureEditApiActionTemplate(Table table)
        {
            return new EditApiActionTemplate
            {
                Route = GenerateActionRoute(table),
                RouteName = $"Edit_{table.SchemaName}_{table.Name.ActualName}",
                FilterableColumns = FindFilterableColumns(table),
                EditableColumns = table.Columns,
                ExistingEntityVariableName = "existing",
                ModelVariableName = "value"
            };
        }

        private DeleteApiActionTemplate ConfigureDeleteApiActionTemplate(Table table)
        {
            return new DeleteApiActionTemplate
            {
                Route = "",
                RouteName = $"Delete_{table.SchemaName}_{table.Name.ActualName}",
                FilterableColumns = FindFilterableColumns(table)
            };
        }

        private static IList<Column> FindFilterableColumns(Table table)
        {
            return table.HasKeyColumn
                ? new List<Column> { table.KeyColumn }
                : table.CompositeKeyColumns.ToList();
        }

        private static string GenerateActionRoute(Table table)
        {
            if (table.HasKeyColumn)
            {
                return $"{{{table.KeyColumn.ActualName.ToCamelCase()}}}";
            }
            var compositeKeys = table.CompositeKeyColumns.ToList();
            var routeParams = compositeKeys.Select(x => $"{x.ActualName.ToCamelCase()}/{{{x.ActualName.ToCamelCase()}}}");
            return string.Join("/", routeParams);
        }
    }
}