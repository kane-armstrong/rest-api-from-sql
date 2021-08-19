using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator
{
    public class PropertyDefinition
    {
        private static readonly string[] AllowedModifiers =
        {
            "abstract",
            "extern",
            "new",
            "override",
            "sealed",
            "static",
            "virtual"
        };

        public string Name { get; }
        public string Type { get; }
        public string Value { get; }
        public List<string> Attributes { get; } = new();
        public List<string> Modifiers { get; } = new();

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

        public void AddModifier(string value)
        {
            if (!AllowedModifiers.Contains(value))
            {
                throw new ArgumentException("Value is not a valid property modifier.");
            }

            if (Modifiers.Contains(value))
            {
                throw new InvalidOperationException("Argument has already been added.");
            }

            if (!Modifiers.Contains("override") && value == "sealed")
            {
                throw new InvalidOperationException("Property cannot be sealed because it is not an override.");
            }

            Modifiers.Add(value);
        }
    }
}
