using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator
{
    public class MethodArgument
    {
        private static readonly string[] AllowedModifiers =
        {
            "ref",
            "out",
            "params",
            "in"
        };

        public string Type { get; }
        public string Name { get; }
        public string Modifier { get; }
        public List<string> Attributes { get; } = new();

        public MethodArgument(string type, string name)
        {
            Type = type;
            Name = name;
        }

        public MethodArgument(string type, string name, string modifier)
        {
            Type = type;
            Name = name;
            if (!AllowedModifiers.Contains(modifier))
            {
                throw new ArgumentException("Modifier is not a valid method argument modifier", nameof(modifier));
            }
            Modifier = modifier;
        }

        public void AddAttribute(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Attribute must have a value");
            }

            if (Attributes.Contains(value))
            {
                throw new InvalidOperationException("Attribute has already been added.");
            }

            Attributes.Add(value);
        }
    }
}