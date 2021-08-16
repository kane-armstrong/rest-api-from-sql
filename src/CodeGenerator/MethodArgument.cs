namespace CodeGenerator
{
    public class MethodArgument
    {
        public string Type { get; }
        public string Name { get; }

        //  TODO validation - throw if type/name invalid
        public MethodArgument(string type, string name)
        {
            Type = type;
            Name = name;
        }
    }
}