using CommandLine;

namespace RestApiFromSqlSchema.Console
{
    public class Options
    {
        [Option('c', "Connection String", Required = true, HelpText = "The connection string to use to connect to the target database")]
        public string ConnectionString { get; set; }

        [Option('d', "Output Directory", Required = true, HelpText = "The full path on disk where the generated code should be saved")]
        public string OutputDirectory { get; set; }

        [Option('s', "Solution Name", Required = true, HelpText = "The name of the solution (sln) file")]
        public string SolutionName { get; set; }

        [Option('p', "Project Name", Required = true, HelpText = "The name of the project (csproj) file")]
        public string ProjectName { get; set; }

        [Option('u', "Generate Unique Key Endpoints", Required = false, HelpText = "Sets whether or not to generate unique key endpoints", Default = true)]
        public bool GenerateUniqueKeyEndpoints { get; set; }

        [Option('s', "Generate Swagger docs", Required = false, HelpText = "Sets whether or not to generate swagger docs (NYI)", Default = true)]
        public bool GenerateSwaggerDocs { get; set; }

        [Option('v', "Generate FluentValidation validators", Required = false, HelpText = "Sets whether or not to generate FluentValidation validators (NYI)", Default = true)]
        public bool GenerateFluentValidationValidators { get; set; }
    }
}