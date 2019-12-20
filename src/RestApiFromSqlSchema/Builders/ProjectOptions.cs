namespace RestApiFromSqlSchema.Builders
{
    public class ProjectOptions
    {
        public ISchemaExplorer SchemaExplorer { get; set; }
        public bool GenerateUniqueKeyEndpoints { get; set; }
        public bool IncludeSwaggerDocs { get; set; } = true;
        public bool GenerateFluentValidationValidators { get; set; }
        public string Name { get; set; }
        public string ConnectionString { get; set; }
    }
}