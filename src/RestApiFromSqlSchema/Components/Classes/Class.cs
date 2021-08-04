using SchemaExplorer;

namespace RestApiFromSqlSchema.Components.Classes
{
    public class Class
    {
        public string FileName { get; }
        public string FileContent { get; }
        public string RelativePath { get; }
        public Table Source { get; }

        public Class(string fileName, string relativePath, string fileContent)
        {
            FileName = fileName;
            FileContent = fileContent;
            RelativePath = relativePath;
        }

        public Class(string fileName, string relativePath, string fileContent, Table source)
        {
            FileName = fileName;
            FileContent = fileContent;
            RelativePath = relativePath;
            Source = source;
        }
    }
}