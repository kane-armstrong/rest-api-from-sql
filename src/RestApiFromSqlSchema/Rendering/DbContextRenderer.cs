using System.Linq;
using System.Text;
using Antlr4.StringTemplate;
using RestApiFromSqlSchema.Components.Templates.EntityFramework;
using RestApiFromSqlSchema.Rendering.Templates;
using RestApiFromSqlSchema.Rendering.Templates.Resources;

namespace RestApiFromSqlSchema.Rendering
{
    public static class DbContextRenderer
    {
        private const string Tab = "\t";
        private const char StartDelimiter = '$';
        private const char EndDelimiter = '$';

        public static string Render(DbContextTemplate configuration)
        {
            var template = new Template(TemplateContent.DbContext, StartDelimiter, EndDelimiter);

            template.Add(SharedTemplateKeys.GeneratedCodeDisclaimer, TemplateContent.GeneratedCodeDisclaimer);
            template.Add(SharedTemplateKeys.ObjectNamespace, configuration.Namespace);
            template.Add(SharedTemplateKeys.ObjectTypeName, configuration.TypeName);

            var dbSetBuilder = new StringBuilder();
            foreach (var dbSet in configuration.DbSets)
            {
                dbSetBuilder.AppendLine($"{Tab}{Tab}public DbSet<{dbSet.Namespace}.{dbSet.TypeName}> {dbSet.Namespace}_{dbSet.TypeName} {{ get; set; }}");
            }
            template.Add(SharedTemplateKeys.DbSets, dbSetBuilder.ToString());

            var keysBuilder = new StringBuilder();
            foreach (var dbSet in configuration.DbSets)
            {
                var text = dbSet.Keys.Count == 1
                    ? $"{Tab}{Tab}{Tab}modelBuilder.Entity<{dbSet.Namespace}.{dbSet.TypeName}>().HasKey(x => x.{dbSet.Keys.First().LegalCsharpName});"
                    : $"{Tab}{Tab}{Tab}modelBuilder.Entity<{dbSet.Namespace}.{dbSet.TypeName}>().HasKey(x => new {{{string.Join(",", dbSet.Keys.Select(x => $"x.{x.LegalCsharpName}"))}}});";
                keysBuilder.AppendLine(text);
            }
            template.Add(SharedTemplateKeys.ModelBuilderKeys, keysBuilder.ToString());

            return template.Render();
        }
    }
}