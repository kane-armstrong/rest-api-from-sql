namespace CodeGenerator
{
    //TODO attributes
    public class PropertyDefinition
    {
        public string Name { get; }
        public string Type { get; }
        public string Value { get; } = "{ get; set; }";

        public PropertyDefinition(string type, string name)
        {
            Name = name;
            Type = type;
        }

        public PropertyDefinition(string name, string type, string value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
}
