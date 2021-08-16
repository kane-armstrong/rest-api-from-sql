namespace CodeGenerator
{
    public class FieldDefinition
    {
        public string Name { get; }
        public string Type { get; }
        public string Value { get; }

        public FieldDefinition(string type, string name)
        {
            Name = name;
            Type = type;
        }

        public FieldDefinition(string type, string name, string value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
}
