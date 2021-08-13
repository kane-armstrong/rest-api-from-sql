namespace CodeGenerator
{
    public class FieldDefinition
    {
        public string Name { get; }
        public string Type { get; }

        public FieldDefinition(string type, string name)
        {
            Name = name;
            Type = type;
        }
    }
}
