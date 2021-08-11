using System.Collections.Generic;

namespace CodeGenerator
{
    public class MethodDefinition
    {
        public MethodAccessibilityLevel AccessibilityLevel { get; internal set; }
        public string ReturnType { get; internal set; }
        public string Name { get; internal set; }
        public IReadOnlyList<MethodArgument> Arguments => _arguments.AsReadOnly();
        public string Body { get; internal set; }

        private readonly List<MethodArgument> _arguments;

        internal MethodDefinition()
        {
            _arguments = new List<MethodArgument>();
        }

        internal void AddArgument(MethodArgument argument)
        {
            _arguments.Add(argument);
        }
    }
}
