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

        private static readonly Regex LegalTypeNameCharacters = new("^[a-zA-Z0-9_]+$");
        private static readonly Regex LegalTypeNameLeadingCharacters = new("^[a-zA-Z_]+$");

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
            EnsureValidNamespace(value);
            _namespace = value;
            return this;
        }

        public ClassBuilder UsingNamespace(string value)
        {
            EnsureValidNamespace(value);
            if (_usingDirectives.Contains(value))
            {
                throw new InvalidOperationException("Namespace has already been added");
            }
            _usingDirectives.Add(value);
            return this;
        }

        private void EnsureValidNamespace(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidOperationException("Invalid namespace");
            }

            var parts = value.Split(".");
            foreach (var part in parts)
            {
                if (!LegalTypeNameCharacters.IsMatch(part)
                    || !LegalTypeNameLeadingCharacters.IsMatch(part[..1]))
                {
                    throw new InvalidOperationException("Invalid namespace");
                }
            }
        }

        public ClassBuilder WithAccessibilityLevel(ClassAccessibilityLevel expected)
        {
            _accessibilityLevel = expected;
            return this;
        }

        public ClassBuilder WithName(string value)
        {
            if (string.IsNullOrEmpty(value)
                || !LegalTypeNameCharacters.IsMatch(value)
                || !LegalTypeNameLeadingCharacters.IsMatch(value[..1]))
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
                || !LegalTypeNameCharacters.IsMatch(definition.Name)
                || !LegalTypeNameLeadingCharacters.IsMatch(definition.Name[..1]))
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
                || !LegalTypeNameCharacters.IsMatch(definition.Name)
                || !LegalTypeNameLeadingCharacters.IsMatch(definition.Name[..1]))
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
                || !LegalTypeNameCharacters.IsMatch(value)
                || !LegalTypeNameLeadingCharacters.IsMatch(value[..1]))
            {
                throw new InvalidOperationException("Invalid base class name");
            }

            _baseClass = value;
            return this;
        }

        public ClassBuilder ImplementingInterface(string value)
        {
            if (string.IsNullOrEmpty(value)
                || !LegalTypeNameCharacters.IsMatch(value)
                || !LegalTypeNameLeadingCharacters.IsMatch(value[..1]))
            {
                throw new InvalidOperationException("Invalid interface name");
            }

            _implementedInterfaces.Add(value);

            return this;
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

            template.Add(SharedTemplateKeys.UsingDirectives, _usingDirectives);
            template.Add(SharedTemplateKeys.Attributes, _attributes);
            template.Add(SharedTemplateKeys.Fields, _fields);
            template.Add(SharedTemplateKeys.Properties, _properties);
            template.Add(SharedTemplateKeys.Constructors, _constructors);
            template.Add(SharedTemplateKeys.MethodDefinitions, _methods);

            return template.Render();
        }
    }
}
