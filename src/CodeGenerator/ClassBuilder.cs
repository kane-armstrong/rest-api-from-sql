using Antlr4.StringTemplate;
using CodeGenerator.Templates;
using CodeGenerator.Templates.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
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

        private static readonly string[] AllowedModifiers =
        {
            "abstract",
            "sealed",
            "static"
        };

        private static readonly Regex LegalTypeNameCharacters = new("^[a-zA-Z0-9_]+$");
        private static readonly Regex LegalTypeNameLeadingCharacters = new("^[a-zA-Z_]+$");

        private string _namespace;
        private string _className;
        private ClassAccessibilityLevel? _accessibilityLevel;
        private string _baseClass;

        private readonly List<string> _modifiers = new();
        private readonly List<string> _usingDirectives = new();
        private readonly List<Method> _methods = new();
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

        private static void EnsureValidNamespace(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid namespace");
            }

            var parts = value.Split(".");
            foreach (var part in parts)
            {
                if (!LegalTypeNameCharacters.IsMatch(part)
                    || !LegalTypeNameLeadingCharacters.IsMatch(part[..1]))
                {
                    throw new ArgumentException("Invalid namespace");
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
                throw new ArgumentException("Invalid class name");
            }
            _className = value;
            return this;
        }

        public ClassBuilder WithMethod(Method method)
        {
            if (method == null)
            {
                throw new ArgumentNullException(nameof(method));
            }

            if (_methods.Any(x =>
                x.Name == method.Name && x.Arguments.All(y => method.Arguments.Any(z => z.Type == y.Type))))
            {
                throw new InvalidOperationException("Method signature conflicts with an existing method signature");
            }

            _methods.Add(method);
            return this;
        }

        public ClassBuilder WithProperty(PropertyDefinition definition)
        {
            if (string.IsNullOrEmpty(definition.Name)
                || !LegalTypeNameCharacters.IsMatch(definition.Name)
                || !LegalTypeNameLeadingCharacters.IsMatch(definition.Name[..1]))
            {
                throw new ArgumentException("Invalid property name");
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
                throw new ArgumentException("Attribute must have a value");
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
                throw new ArgumentException("Constructor must have a value");
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
                throw new ArgumentException("Invalid field name");
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
                throw new ArgumentException("Invalid base class name");
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
                throw new ArgumentException("Invalid interface name");
            }

            _implementedInterfaces.Add(value);

            return this;
        }

        public ClassBuilder WithModifier(string value)
        {
            if (!AllowedModifiers.Contains(value))
            {
                throw new ArgumentException($"Modifier '{value}' is not a valid class modifier.");
            }

            if (_modifiers.Contains(value))
            {
                throw new InvalidOperationException("Modifier has already been added.");
            }

            if (_modifiers.Contains("abstract") && value == "static")
            {
                throw new InvalidOperationException("An abstract class cannot be static.");
            }

            if (_modifiers.Contains("static") && value == "abstract")
            {
                throw new InvalidOperationException("An static class cannot be abstract.");
            }

            if (_modifiers.Contains("sealed") && value == "static")
            {
                throw new InvalidOperationException("A sealed class cannot be static.");
            }

            if (_modifiers.Contains("static") && value == "sealed")
            {
                throw new InvalidOperationException("An static class cannot be sealed.");
            }

            _modifiers.Add(value);

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

            template.Add(ClassTemplateAttributes.Namespace, _namespace);
            template.Add(ClassTemplateAttributes.AccessibilityLevel, ClassAccessibilityLevelMap[_accessibilityLevel.Value]);
            template.Add(ClassTemplateAttributes.Modifiers, _modifiers);
            template.Add(ClassTemplateAttributes.Name, _className);
            template.Add(ClassTemplateAttributes.UsingDirectives, _usingDirectives);
            template.Add(ClassTemplateAttributes.Attributes, _attributes);
            template.Add(ClassTemplateAttributes.BaseClass, _baseClass);
            template.Add(ClassTemplateAttributes.ImplementedInterfaces, _implementedInterfaces);
            template.Add(ClassTemplateAttributes.Fields, _fields);
            template.Add(ClassTemplateAttributes.Properties, _properties);
            template.Add(ClassTemplateAttributes.Constructors, _constructors);
            template.Add(ClassTemplateAttributes.Methods, _methods.Select(x => x.Render()));

            return template.Render();
        }
    }
}
