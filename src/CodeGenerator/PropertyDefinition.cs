namespace CodeGenerator
{
    public class PropertyDefinition
    {
        public string Name { get; }
        public string Type { get; }

        public PropertyDefinition(string type, string name)
        {
            Name = name;
            Type = type;
        }
    }
}
