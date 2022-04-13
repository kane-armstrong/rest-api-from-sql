using CommandLine;
using RestApiFromSqlSchema.Builders;
using SchemaExplorer.SqlServer;
using System;
using System.Threading.Tasks;

namespace RestApiFromSqlSchema.Console;

internal static class Program
{
    private static async Task Main(string[] args)
    {
        using var parser = new Parser(parserOptions =>
        {
            parserOptions.HelpWriter = System.Console.Error;
            parserOptions.CaseSensitive = false;
            parserOptions.IgnoreUnknownArguments = true;
            parserOptions.EnableDashDash = true;
        });

        Options options = null;
        parser.ParseArguments<Options>(args)
            .WithParsed(parserOptions =>
            {
                options = parserOptions;
            })
            .WithNotParsed(_ =>
            {
                Environment.Exit(1);
            });

        var solutionBuilder = new SolutionBuilder(solutionOptions =>
            {
                solutionOptions.Name = options.SolutionName;
                solutionOptions.Directory = options.OutputDirectory;
            })
            .AddProject(projectOptions =>
            {
                projectOptions.Name = options.ProjectName;
                projectOptions.SchemaExplorer = new SqlServerSchemaExplorer(options.ConnectionString);
                projectOptions.GenerateUniqueKeyEndpoints = options.GenerateUniqueKeyEndpoints;
                projectOptions.IncludeSwaggerDocs = options.GenerateSwaggerDocs;
                projectOptions.GenerateFluentValidationValidators = options.GenerateFluentValidationValidators;
                projectOptions.ConnectionString = options.ConnectionString;
            });

        var solution = await solutionBuilder.BuildAsync();
        solution.SaveChanges();
    }
}