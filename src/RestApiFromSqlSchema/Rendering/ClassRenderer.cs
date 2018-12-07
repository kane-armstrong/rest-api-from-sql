using Antlr4.StringTemplate;
using Armsoft.RestApiFromSqlSchema.Components.Templates;
using Armsoft.RestApiFromSqlSchema.Rendering.Templates;
using Armsoft.RestApiFromSqlSchema.Rendering.Templates.Resources;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Armsoft.RestApiFromSqlSchema.Rendering
{
    public static class ClassRenderer
    {
        private const string Tab = "\t";
        private const char StartDelimiter = '$';
        private const char EndDelimiter = '$';

        private static readonly List<string> NotMappedDataTypes = new List<string>
        {
            "object"
        };

        public static string Render(ClassTemplate configuration)
        {
            var template = new Template(TemplateContent.Class, StartDelimiter, EndDelimiter);

            template.Add(SharedTemplateKeys.GeneratedCodeDisclaimer, TemplateContent.GeneratedCodeDisclaimer);
            template.Add(SharedTemplateKeys.ObjectNamespace, configuration.Namespace);
            template.Add(SharedTemplateKeys.ObjectTypeName, configuration.TypeName);

            var classPropertiesBuilder = new StringBuilder();
            var columns = configuration.Properties.OrderBy(x => x.Order);
            foreach (var column in columns)
            {
                if (NotMappedDataTypes.Contains(column.DataType))
                {
                    classPropertiesBuilder.AppendLine($"{Tab}{Tab}[NotMapped]");
                }
                classPropertiesBuilder.AppendLine($"{Tab}{Tab}[Column(\"{column.Name.ActualName}\")]");
                classPropertiesBuilder.AppendLine($"{Tab}{Tab}public {column.DataType} {column.Name.LegalCsharpName} {{ get; set; }}");
            }

            template.Add(SharedTemplateKeys.ClassProperties, classPropertiesBuilder.ToString());

            return template.Render();
        }
    }
}