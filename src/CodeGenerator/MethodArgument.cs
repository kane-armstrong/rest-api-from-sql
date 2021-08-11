namespace CodeGenerator
{
    public class MethodArgument
    {
        public string Type { get; }
        public string Name { get; }

        public MethodArgument(string type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}