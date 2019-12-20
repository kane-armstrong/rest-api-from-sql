using System;
using Armsoft.RestApiFromSqlSchema.Builders;
using Armsoft.RestApiFromSqlSchema.SqlServer;
using CommandLine;

namespace Armsoft.RestApiFromSqlSchema.CLI
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            using var parser = new Parser(options =>
            {
                options.HelpWriter = Console.Error;
                options.CaseSensitive = false;
                options.IgnoreUnknownArguments = true;
                options.EnableDashDash = true;
            });

            parser.ParseArguments<Options>(args)
                .WithParsed(parserOptions =>
                {
                    var solution = new SolutionBuilder(solutionOptions =>
                        {
                            solutionOptions.Name = parserOptions.SolutionName;
                            solutionOptions.Directory = parserOptions.OutputDirectory;
                        })
                        .AddProject(projectOptions =>
                        {
                            projectOptions.Name = parserOptions.ProjectName;
                            projectOptions.SchemaExplorer = new SqlServerSchemaExplorer(parserOptions.ConnectionString);
                            projectOptions.GenerateUniqueKeyEndpoints = parserOptions.GenerateUniqueKeyEndpoints;
                            projectOptions.IncludeSwaggerDocs = parserOptions.GenerateSwaggerDocs;
                            projectOptions.GenerateFluentValidationValidators = parserOptions.GenerateFluentValidationValidators;
                            projectOptions.ConnectionString = parserOptions.ConnectionString;
                        })
                        .BuildAsync().GetAwaiter().GetResult();

                    solution.SaveChanges();
                })
                .WithNotParsed(options =>
                {
                    Environment.Exit(1);
                });
        }
    }
}