using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator.Classes
{
    public class Field
    {
        private static readonly string[] AllowedModifiers =
        {
            "const",
            "new",
            "readonly",
            "static",
            "volatile"
        };

        public string Name { get; }
        public string Type { get; }
        public string Value { get; }
        public List<string> Modifiers { get; } = new();

        public Field(string type, string name)
        {
            Name = name;
            Type = type;
        }

        public Field(string type, string name, string value)
        {
            Name = name;
            Type = type;
            Value = value;
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

            if (value == "const" && Value == null)
            {
                throw new InvalidOperationException("A field cannot be marked const when it does not have a value.");
            }

            Modifiers.Add(value);
        }
    }
}
