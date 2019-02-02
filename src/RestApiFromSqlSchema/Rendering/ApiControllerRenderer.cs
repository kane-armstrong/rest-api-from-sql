using Antlr4.StringTemplate;
using Armsoft.RestApiFromSqlSchema.Components.Schema;
using Armsoft.RestApiFromSqlSchema.Components.Templates.WebApi;
using Armsoft.RestApiFromSqlSchema.Extensions;
using Armsoft.RestApiFromSqlSchema.Rendering.Templates;
using Armsoft.RestApiFromSqlSchema.Rendering.Templates.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Armsoft.RestApiFromSqlSchema.Rendering
{
    public static class ApiControllerRenderer
    {
        private const string Tab = "\t";
        private const char StartDelimiter = '$';
        private const char EndDelimiter = '$';

        public static string Render(ApiControllerTemplate configuration)
        {
            var template = new Template(TemplateContent.ApiController, StartDelimiter, EndDelimiter);

            template.Add(SharedTemplateKeys.GeneratedCodeDisclaimer, TemplateContent.GeneratedCodeDisclaimer);
            template.Add(SharedTemplateKeys.ObjectNamespace, configuration.Namespace);
            template.Add(SharedTemplateKeys.ObjectTypeName, configuration.TypeName);

            if (configuration.IncludeUniqueKeyActions)
            {
                var getByUniqueKeyActionsBuilder = new StringBuilder();
                foreach (var item in configuration.GetByUniqueKeyTemplates)
                {
                    getByUniqueKeyActionsBuilder.AppendLine(RenderGetByUniqueKeyAction(item, configuration.Namespace, configuration.TypeName));
                }
                template.Add(SharedTemplateKeys.GetByUniqueKeyActions, getByUniqueKeyActionsBuilder.ToString());

                var editByUniqueKeyActionsBuilder = new StringBuilder();
                foreach (var item in configuration.EditByUniqueKeyTemplates)
                {
                    editByUniqueKeyActionsBuilder.AppendLine(RenderEditByUniqueKeyAction(item, configuration.Namespace, configuration.TypeName));
                }
                template.Add(SharedTemplateKeys.EditByUniqueKeyActions, editByUniqueKeyActionsBuilder.ToString());

                var deleteByUniqueKeyActionsBuilder = new StringBuilder();
                foreach (var item in configuration.DeleteByUniqueKeyTemplates)
                {
                    deleteByUniqueKeyActionsBuilder.AppendLine(RenderDeleteByUniqueKeyAction(item, configuration.Namespace, configuration.TypeName));
                }
                template.Add(SharedTemplateKeys.DeleteByUniqueKeyActions, deleteByUniqueKeyActionsBuilder.ToString());
            }
            else
            {
                template.Add(SharedTemplateKeys.GetByUniqueKeyActions, $"{Tab}{Tab}// No {nameof(SharedTemplateKeys.GetByUniqueKeyActions)} generated");
                template.Add(SharedTemplateKeys.EditByUniqueKeyActions, $"{Tab}{Tab}// No {nameof(SharedTemplateKeys.EditByUniqueKeyActions)} generated");
                template.Add(SharedTemplateKeys.DeleteByUniqueKeyActions, $"{Tab}{Tab}// No {nameof(SharedTemplateKeys.DeleteByUniqueKeyActions)} generated");
            }

            template.Add(SharedTemplateKeys.ListAction, RenderListAction(configuration.ListApiActionTemplate, configuration.Namespace, configuration.TypeName));
            template.Add(SharedTemplateKeys.GetByIdAction, RenderGetByIdAction(configuration.GetByIdApiActionTemplate, configuration.Namespace, configuration.TypeName));
            template.Add(SharedTemplateKeys.CreateAction, RenderCreateAction(configuration.CreateApiActionTemplate, configuration.Namespace, configuration.TypeName));
            template.Add(SharedTemplateKeys.EditAction, RenderEditAction(configuration.EditApiActionTemplate, configuration.Namespace, configuration.TypeName));
            template.Add(SharedTemplateKeys.DeleteAction, RenderDeleteAction(configuration.DeleteApiActionTemplate, configuration.Namespace, configuration.TypeName));

            return template.Render();
        }

        private static string RenderGetByUniqueKeyAction(GetByIdApiActionTemplate configuration, string typeNamespace, string typeName)
        {
            var identifiers = configuration.FilterableColumns.Count == 1
                ? GenerateIdentifiers(configuration.FilterableColumns.First())
                : GenerateIdentifiers(configuration.FilterableColumns);

            var template = new Template(TemplateContent.ApiActionGetByUniqueKey, StartDelimiter, EndDelimiter);

            template.Add(SharedTemplateKeys.Route, configuration.Route);
            template.Add(SharedTemplateKeys.RouteName, configuration.RouteName);
            template.Add(SharedTemplateKeys.ObjectNamespace, typeNamespace);
            template.Add(SharedTemplateKeys.ObjectTypeName, typeName);
            template.Add(SharedTemplateKeys.Identifiers, identifiers.Identifier);
            template.Add(SharedTemplateKeys.IdentifiersPredicate, identifiers.Predicate);

            return template.Render();
        }

        private static string RenderEditByUniqueKeyAction(EditApiActionTemplate configuration, string typeNamespace, string typeName)
        {
            var identifiers = configuration.FilterableColumns.Count == 1
                ? GenerateIdentifiers(configuration.FilterableColumns.First())
                : GenerateIdentifiers(configuration.FilterableColumns);

            var editBuilder = new StringBuilder();
            var editableColumns = configuration.KeyColumns != null && configuration.KeyColumns.Any()
                ? configuration.EditableColumns.Except(configuration.KeyColumns)
                : configuration.EditableColumns;
            foreach (var column in editableColumns)
            {
                editBuilder.AppendLine($"{Tab}{Tab}{Tab}{configuration.ExistingEntityVariableName}.{column.LegalCsharpName} = {configuration.ModelVariableName}.{column.LegalCsharpName};");
            }

            var template = new Template(TemplateContent.ApiActionEditByUniqueKey, StartDelimiter, EndDelimiter);

            template.Add(SharedTemplateKeys.Route, configuration.Route);
            template.Add(SharedTemplateKeys.RouteName, configuration.RouteName);
            template.Add(SharedTemplateKeys.ObjectNamespace, typeNamespace);
            template.Add(SharedTemplateKeys.ObjectTypeName, typeName);
            template.Add(SharedTemplateKeys.Identifiers, identifiers.Identifier);
            template.Add(SharedTemplateKeys.IdentifiersPredicate, identifiers.Predicate);
            template.Add(SharedTemplateKeys.ExistingEntityVariableName, configuration.ExistingEntityVariableName);
            template.Add(SharedTemplateKeys.ModelVariableName, configuration.ModelVariableName);
            template.Add(SharedTemplateKeys.EditActionEdits, editBuilder.ToString());

            return template.Render();
        }

        private static string RenderDeleteByUniqueKeyAction(DeleteApiActionTemplate configuration, string typeNamespace, string typeName)
        {
            var identifiers = configuration.FilterableColumns.Count == 1
                ? GenerateIdentifiers(configuration.FilterableColumns.First())
                : GenerateIdentifiers(configuration.FilterableColumns);

            var template = new Template(TemplateContent.ApiActionDeleteByUniqueKey, StartDelimiter, EndDelimiter);

            template.Add(SharedTemplateKeys.Route, configuration.Route);
            template.Add(SharedTemplateKeys.RouteName, configuration.RouteName);
            template.Add(SharedTemplateKeys.ObjectNamespace, typeNamespace);
            template.Add(SharedTemplateKeys.ObjectTypeName, typeName);
            template.Add(SharedTemplateKeys.Identifiers, identifiers.Identifier);
            template.Add(SharedTemplateKeys.IdentifiersPredicate, identifiers.Predicate);

            return template.Render();
        }

        private static string RenderListAction(ListApiActionTemplate configuration, string typeNamespace, string typeName)
        {
            var template = new Template(TemplateContent.ApiActionList, StartDelimiter, EndDelimiter);

            template.Add(SharedTemplateKeys.Route, configuration.Route);
            template.Add(SharedTemplateKeys.RouteName, configuration.RouteName);
            template.Add(SharedTemplateKeys.ObjectNamespace, typeNamespace);
            template.Add(SharedTemplateKeys.ObjectTypeName, typeName);
            template.Add(SharedTemplateKeys.OrderBy, GenerateOrderBy(configuration.OrderByColumns));

            return template.Render();
        }

        private static object RenderGetByIdAction(GetByIdApiActionTemplate configuration, string typeNamespace, string typeName)
        {
            var identifiers = configuration.FilterableColumns.Count == 1
                ? GenerateIdentifiers(configuration.FilterableColumns.First())
                : GenerateIdentifiers(configuration.FilterableColumns);

            var template = new Template(TemplateContent.ApiActionGetById, StartDelimiter, EndDelimiter);

            template.Add(SharedTemplateKeys.Route, configuration.Route);
            template.Add(SharedTemplateKeys.RouteName, configuration.RouteName);
            template.Add(SharedTemplateKeys.ObjectNamespace, typeNamespace);
            template.Add(SharedTemplateKeys.ObjectTypeName, typeName);
            template.Add(SharedTemplateKeys.Identifiers, identifiers.Identifier);
            template.Add(SharedTemplateKeys.IdentifiersPredicate, identifiers.Predicate);

            return template.Render();
        }

        private static object RenderCreateAction(CreateApiActionTemplate configuration, string typeNamespace, string typeName)
        {
            var template = new Template(TemplateContent.ApiActionCreate, StartDelimiter, EndDelimiter);

            template.Add(SharedTemplateKeys.Route, configuration.Route);
            template.Add(SharedTemplateKeys.RouteName, configuration.RouteName);
            template.Add(SharedTemplateKeys.ObjectNamespace, typeNamespace);
            template.Add(SharedTemplateKeys.ObjectTypeName, typeName);

            return template.Render();
        }

        private static object RenderEditAction(EditApiActionTemplate configuration, string typeNamespace, string typeName)
        {
            var identifiers = configuration.FilterableColumns.Count == 1
                ? GenerateIdentifiers(configuration.FilterableColumns.First())
                : GenerateIdentifiers(configuration.FilterableColumns);

            var editBuilder = new StringBuilder();
            foreach (var column in configuration.EditableColumns)
            {
                editBuilder.AppendLine($"{Tab}{Tab}{Tab}{configuration.ExistingEntityVariableName}.{column.LegalCsharpName} = {configuration.ModelVariableName}.{column.LegalCsharpName};");
            }

            var template = new Template(TemplateContent.ApiActionEdit, StartDelimiter, EndDelimiter);

            template.Add(SharedTemplateKeys.Route, configuration.Route);
            template.Add(SharedTemplateKeys.RouteName, configuration.RouteName);
            template.Add(SharedTemplateKeys.ObjectNamespace, typeNamespace);
            template.Add(SharedTemplateKeys.ObjectTypeName, typeName);
            template.Add(SharedTemplateKeys.Identifiers, identifiers.Identifier);
            template.Add(SharedTemplateKeys.IdentifiersPredicate, identifiers.Predicate);
            template.Add(SharedTemplateKeys.ExistingEntityVariableName, configuration.ExistingEntityVariableName);
            template.Add(SharedTemplateKeys.ModelVariableName, configuration.ModelVariableName);
            template.Add(SharedTemplateKeys.EditActionEdits, editBuilder.ToString());

            return template.Render();
        }

        private static object RenderDeleteAction(DeleteApiActionTemplate configuration, string typeNamespace, string typeName)
        {
            var identifiers = configuration.FilterableColumns.Count == 1
                ? GenerateIdentifiers(configuration.FilterableColumns.First())
                : GenerateIdentifiers(configuration.FilterableColumns);

            var template = new Template(TemplateContent.ApiActionDelete, StartDelimiter, EndDelimiter);

            template.Add(SharedTemplateKeys.Route, configuration.Route);
            template.Add(SharedTemplateKeys.RouteName, configuration.RouteName);
            template.Add(SharedTemplateKeys.ObjectNamespace, typeNamespace);
            template.Add(SharedTemplateKeys.ObjectTypeName, typeName);
            template.Add(SharedTemplateKeys.Identifiers, identifiers.Identifier);
            template.Add(SharedTemplateKeys.IdentifiersPredicate, identifiers.Predicate);

            return template.Render();
        }

        private static IdentifierConfiguration GenerateIdentifiers(Column column)
        {
            var identifiers = $"{column.DataType} {column.Name.ActualName.ToCamelCase()}";
            var identifiersPredicate = $"x => x.{column.LegalCsharpName} == {column.Name.ActualName.ToCamelCase()}";
            return new IdentifierConfiguration(identifiers, identifiersPredicate);
        }

        private static IdentifierConfiguration GenerateIdentifiers(IList<Column> columns)
        {
            var keys = columns.Select(x => $"{x.DataType} {x.ActualName.ToCamelCase()}");
            var predicate = columns.Select(x => $"x.{x.LegalCsharpName} == {x.ActualName.ToCamelCase()}");

            var identifiers = string.Join(", ", keys);
            var identifiersPredicate = $"x => {string.Join(" && ", predicate)}";
            return new IdentifierConfiguration(identifiers, identifiersPredicate);
        }

        private static string GenerateOrderBy(IList<Column> columns)
        {
            var orderByBuilder = new StringBuilder();
            for (var i = 0; i < columns.Count; i++)
            {
                if (i == 0)
                {
                    orderByBuilder.Append($"OrderBy(x => x.{columns[i].ActualName}).");
                    continue;
                }

                orderByBuilder.Append($"ThenBy(x => x.{columns[i].ActualName}).");
            }
            return orderByBuilder.ToString();
        }
    }
}