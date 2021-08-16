namespace CodeGenerator
{
    //TODO attributes
    public class PropertyDefinition
    {
        public string Name { get; }
        public string Type { get; }
        public string Value { get; }

        public PropertyDefinition(string type, string name)
        {
            Name = name;
            Type = type;
        }

        public PropertyDefinition(string type, string name, string value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
}
