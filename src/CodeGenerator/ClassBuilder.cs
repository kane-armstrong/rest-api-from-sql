using Antlr4.StringTemplate;
using CodeGenerator.Templates;
using CodeGenerator.Templates.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeGenerator
{
    public class ClassBuilder
    {
        private const char StartDelimiter = '$';
        private const char EndDelimiter = '$';

        private static readonly Dictionary<ClassAccessibilityLevel, string> ClassAccessibilityLevelMap = new()
        {
            { ClassAccessibilityLevel.Internal, "internal" },
            { ClassAccessibilityLevel.Public, "public" },
            { ClassAccessibilityLevel.Private, "private" },
            { ClassAccessibilityLevel.PrivateProtected, "private protected" },
            { ClassAccessibilityLevel.Protected, "protected" },
            { ClassAccessibilityLevel.ProtectedInternal, "protected internal" }
        };

        // TODO Tidy up regex - probably don't need two sets, try do whitespace check and first char check in one regex
        private static readonly Regex LegalNamespaceCharacters = new("^[a-zA-Z0-9_.]+$");
        private static readonly Regex LegalNamespaceLeadingCharacters = new("^[a-zA-Z_]+$");

        private static readonly Regex LegalClassNameCharacters = new("^[a-zA-Z0-9_]+$");
        private static readonly Regex LegalClassNameLeadingCharacters = new("^[a-zA-Z_]+$");

        private static readonly Regex LegalPropertyCharacters = new("^[a-zA-Z0-9_]+$");
        private static readonly Regex LegalPropertyLeadingCharacters = new("^[a-zA-Z_]+$");

        private static readonly Regex LegalFieldCharacters = new("^[a-zA-Z0-9_]+$");
        private static readonly Regex LegalFieldLeadingCharacters = new("^[a-zA-Z_]+$");

        private static readonly Regex LegalInterfaceCharacters = new("^[a-zA-Z0-9_]+$");
        private static readonly Regex LegalInterfaceLeadingCharacters = new("^[a-zA-Z_]+$");

        private string _namespace;
        private string _className;
        private ClassAccessibilityLevel? _accessibilityLevel;

        private string _baseClass;

        private readonly List<string> _usingDirectives = new();
        private readonly List<string> _methods = new();
        private readonly List<PropertyDefinition> _properties = new();
        private readonly List<string> _attributes = new();
        private readonly List<string> _constructors = new();
        private readonly List<FieldDefinition> _fields = new();
        private readonly List<string> _implementedInterfaces = new();

        public ClassBuilder WithNamespace(string value)
        {
            if (string.IsNullOrEmpty(value)
                || !LegalNamespaceCharacters.IsMatch(value)
                || !LegalNamespaceLeadingCharacters.IsMatch(value[..1]))
            {
                throw new InvalidOperationException("Invalid namespace");
            }
            _namespace = value;
            return this;
        }

        public ClassBuilder UsingNamespace(string value)
        {
            if (string.IsNullOrEmpty(value)
                || !LegalNamespaceCharacters.IsMatch(value)
                || !LegalNamespaceLeadingCharacters.IsMatch(value[..1]))
            {
                throw new InvalidOperationException("Invalid namespace");
            }

            if (_usingDirectives.Contains(value))
            {
                throw new InvalidOperationException("Namespace has already been added");
            }
            _usingDirectives.Add(value);
            return this;
        }

        public ClassBuilder WithAccessibilityLevel(ClassAccessibilityLevel expected)
        {
            _accessibilityLevel = expected;
            return this;
        }

        public ClassBuilder WithName(string value)
        {
            if (string.IsNullOrEmpty(value)
                || !LegalClassNameCharacters.IsMatch(value)
                || !LegalClassNameLeadingCharacters.IsMatch(value[..1]))
            {
                throw new InvalidOperationException("Invalid class name");
            }
            _className = value;
            return this;
        }

        public ClassBuilder WithMethod(string definition)
        {
            if (definition == null)
            {
                throw new InvalidOperationException("Method definition is required");
            }
            _methods.Add(definition);
            return this;
        }

        public ClassBuilder WithProperty(PropertyDefinition definition)
        {
            if (string.IsNullOrEmpty(definition.Name)
                || !LegalPropertyCharacters.IsMatch(definition.Name)
                || !LegalPropertyLeadingCharacters.IsMatch(definition.Name[..1]))
            {
                throw new InvalidOperationException("Invalid property name");
            }

            if (_properties.Any(x => x.Name == definition.Name))
            {
                throw new InvalidOperationException("Property has already been added");
            }

            if (definition.Name == _className)
            {
                throw new InvalidOperationException("Property name cannot be the same as the enclosing type");
            }

            _properties.Add(definition);

            return this;
        }

        public ClassBuilder WithAttribute(string definition)
        {
            if (string.IsNullOrEmpty(definition))
            {
                throw new InvalidOperationException("Attribute must have a value");
            }

            if (_attributes.Contains(definition))
            {
                throw new InvalidOperationException("Attribute has already been added");

            }

            _attributes.Add(definition);

            return this;
        }

        public ClassBuilder WithConstructor(string definition)
        {
            if (string.IsNullOrEmpty(definition))
            {
                throw new InvalidOperationException("Constructor must have a value");
            }

            if (_constructors.Contains(definition))
            {
                throw new InvalidOperationException("Constructor has already been added");

            }

            _constructors.Add(definition);

            return this;
        }

        public ClassBuilder WithField(FieldDefinition definition)
        {
            if (string.IsNullOrEmpty(definition.Name)
                || !LegalFieldCharacters.IsMatch(definition.Name)
                || !LegalFieldLeadingCharacters.IsMatch(definition.Name[..1]))
            {
                throw new InvalidOperationException("Invalid field name");
            }

            if (_fields.Any(x => x.Name == definition.Name))
            {
                throw new InvalidOperationException("Field has already been added");
            }

            if (definition.Name == _className)
            {
                throw new InvalidOperationException("Field name cannot be the same as the enclosing type");
            }

            _fields.Add(definition);

            return this;
        }

        public ClassBuilder WithBaseClass(string value)
        {
            if (string.IsNullOrEmpty(value)
                || !LegalClassNameCharacters.IsMatch(value)
                || !LegalClassNameLeadingCharacters.IsMatch(value[..1]))
            {
                throw new InvalidOperationException("Invalid base class name");
            }

            _baseClass = value;
            return this;
        }

        public ClassBuilder ImplementingInterface(string value)
        {
            if (string.IsNullOrEmpty(value)
                || !LegalInterfaceCharacters.IsMatch(value)
                || !LegalNamespaceLeadingCharacters.IsMatch(value[..1]))
            {
                throw new InvalidOperationException("Invalid interface name");
            }

            _implementedInterfaces.Add(value);

            return this;
        }

        private string EnsureCorrectIndentation(string input)
        {
            const string padding = "    ";

            var sb = new StringBuilder();

            var openingBracketCount = 0;

            var lines = input.Split(Environment.NewLine);

            foreach (var line in lines)
            {
                var text = line.TrimStart().TrimStart('\t').TrimEnd();

                if (text.Contains("}") && !text.Contains("{"))
                {
                    openingBracketCount--;
                }

                for (var i = 0; i < openingBracketCount; i++)
                {
                    text = padding + text;
                }

                if (text.Contains("{") && !text.Contains("}"))
                {
                    openingBracketCount++;
                }

                sb.AppendLine(text);
            }

            return sb.ToString();
        }

        private string RemoveExcessWhiteSpace(string input)
        {
            var sb = new StringBuilder();

            var lines = input.Split(Environment.NewLine).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

            for (var i = 0; i < lines.Length; i++)
            {
                var currentLine = lines[i];

                sb.AppendLine(currentLine);

                if (i == lines.Length - 1 || i == 0)
                {
                    continue;
                }

                var previousLine = lines[i - 1];
                var nextLine = lines[i + 1];

                var lastIndexOfCurrentLine = currentLine.Length - 1;
                var lastCharacterOfCurrentLine = currentLine[lastIndexOfCurrentLine..];

                var lastIndexOfNextLine = nextLine.Length - 1;
                var lastCharacterOfNextLine = nextLine[lastIndexOfNextLine..];

                if (lastCharacterOfCurrentLine == "}" && lastCharacterOfNextLine != "}" && !string.IsNullOrWhiteSpace(previousLine))
                {
                    sb.Append(Environment.NewLine);
                }
                else if (nextLine.Contains("namespace "))
                {
                    sb.Append(Environment.NewLine);
                }
            }
            
            return sb.ToString();
        }

        public string Build()
        {
            if (_namespace == null)
            {
                throw new InvalidOperationException("A namespace is required");
            }
            if (_className == null)
            {
                throw new InvalidOperationException("A class name is required");
            }
            if (_accessibilityLevel == null)
            {
                throw new InvalidOperationException("An access modifier is required");
            }

            var template = new Template(TemplateContent.Class, StartDelimiter, EndDelimiter);

            template.Add(SharedTemplateKeys.ClassNamespace, _namespace);
            template.Add(SharedTemplateKeys.ClassName, _className);
            template.Add(SharedTemplateKeys.ClassAccessibilityLevel, ClassAccessibilityLevelMap[_accessibilityLevel.Value]);

            var sb = new StringBuilder();

            foreach (var attribute in _attributes)
            {
                sb.AppendLine(attribute);
            }
            template.Add(SharedTemplateKeys.Attributes, sb.ToString());

            sb.Clear();

            foreach (var usingDirective in _usingDirectives)
            {
                sb.AppendLine($"using {usingDirective};");
            }
            template.Add(SharedTemplateKeys.UsingDirectives, sb.ToString());

            sb.Clear();

            foreach (var field in _fields)
            {
                sb.AppendLine($"private {field.Type} {field.Name};");
            }
            template.Add(SharedTemplateKeys.Fields, sb.ToString());

            sb.Clear();

            foreach (var property in _properties)
            {
                sb.AppendLine($"public {property.Type} {property.Name}" + " { get; set; } ");
            }
            template.Add(SharedTemplateKeys.Properties, sb.ToString());

            sb.Clear();

            foreach (var ctor in _constructors)
            {
                sb.AppendLine(ctor);
            }
            template.Add(SharedTemplateKeys.Constructors, sb.ToString());

            sb.Clear();

            foreach (var method in _methods)
            {
                sb.AppendLine();
                sb.AppendLine(method);
            }
            template.Add(SharedTemplateKeys.MethodDefinitions, sb.ToString());

            if (_baseClass != null)
            {
                template.Add(SharedTemplateKeys.BaseClass, $" : {_baseClass}");
            }

            if (_implementedInterfaces.Any())
            {
                var prefix = _baseClass != null ? ", " : " : ";
                var text = $"{prefix}{string.Join(", ", _implementedInterfaces)}";
                template.Add(SharedTemplateKeys.ImplementedInterfaces, text);
            }

            return RemoveExcessWhiteSpace(EnsureCorrectIndentation(template.Render()));
        }
    }
}
