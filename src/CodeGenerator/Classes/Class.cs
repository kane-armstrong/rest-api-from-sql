using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Antlr4.StringTemplate;
using CodeGenerator.Classes.Templates;
using CodeGenerator.Classes.Templates.Resources;

namespace CodeGenerator.Classes
{
    public class Class
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

        private readonly List<string> _modifiers = new();
        private readonly List<string> _usingDirectives = new();
        private readonly List<Method> _methods = new();
        private readonly List<Property> _properties = new();
        private readonly List<string> _attributes = new();
        private readonly List<string> _constructors = new();
        private readonly List<Field> _fields = new();
        private readonly List<string> _implementedInterfaces = new();

        public string Namespace { get; }
        public string ClassName { get; }
        public ClassAccessibilityLevel AccessibilityLevel { get; }
        public string BaseClass { get; private set; }

        public IReadOnlyList<string> Modifiers => _modifiers;
        public IReadOnlyList<string> UsingDirectives => _usingDirectives;
        public IReadOnlyList<Method> Methods => _methods;
        public IReadOnlyList<Property> Properties => _properties;
        public IReadOnlyList<string> Attributes => _attributes;
        public IReadOnlyList<string> Constructors => _constructors;
        public IReadOnlyList<Field> Fields => _fields;
        public IReadOnlyList<string> ImplementedInterfaces => _implementedInterfaces;

        public Class(string classNamespace, ClassAccessibilityLevel classAccessibilityLevel,  string className)
        {
            EnsureValidNamespace(classNamespace);
            Namespace = classNamespace;

            AccessibilityLevel = classAccessibilityLevel;

            if (string.IsNullOrEmpty(className)
                || !LegalTypeNameCharacters.IsMatch(className)
                || !LegalTypeNameLeadingCharacters.IsMatch(className[..1]))
            {
                throw new ArgumentException("Invalid class name", nameof(className));
            }

            ClassName = className;
        }

        public void AddUsingDirective(string value)
        {
            EnsureValidNamespace(value);
            if (_usingDirectives.Contains(value))
            {
                throw new InvalidOperationException("Namespace has already been added");
            }
            _usingDirectives.Add(value);
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
        
        public void AddMethod(Method method)
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
        }

        public void AddProperty(Property definition)
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

            if (definition.Name == ClassName)
            {
                throw new InvalidOperationException("Property name cannot be the same as the enclosing type");
            }

            _properties.Add(definition);
        }

        public void AddAttribute(string definition)
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
        }

        public void AddConstructor(string definition)
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
        }

        public void AddField(Field definition)
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

            if (definition.Name == ClassName)
            {
                throw new InvalidOperationException("Field name cannot be the same as the enclosing type");
            }

            _fields.Add(definition);
        }

        public void AddBaseClass(string value)
        {
            if (string.IsNullOrEmpty(value)
                || !LegalTypeNameCharacters.IsMatch(value)
                || !LegalTypeNameLeadingCharacters.IsMatch(value[..1]))
            {
                throw new ArgumentException("Invalid base class name");
            }

            BaseClass = value;
        }

        public void AddInterface(string value)
        {
            if (string.IsNullOrEmpty(value)
                || !LegalTypeNameCharacters.IsMatch(value)
                || !LegalTypeNameLeadingCharacters.IsMatch(value[..1]))
            {
                throw new ArgumentException("Invalid interface name");
            }

            _implementedInterfaces.Add(value);
        }

        public void AddModifier(string value)
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
        }

        public string Render()
        {
            var template = new Template(TemplateContent.Class, StartDelimiter, EndDelimiter);

            template.Add(ClassTemplateAttributes.Namespace, Namespace);
            template.Add(ClassTemplateAttributes.AccessibilityLevel, ClassAccessibilityLevelMap[AccessibilityLevel]);
            template.Add(ClassTemplateAttributes.Modifiers, _modifiers);
            template.Add(ClassTemplateAttributes.Name, ClassName);
            template.Add(ClassTemplateAttributes.UsingDirectives, _usingDirectives);
            template.Add(ClassTemplateAttributes.Attributes, _attributes);
            template.Add(ClassTemplateAttributes.BaseClass, BaseClass);
            template.Add(ClassTemplateAttributes.ImplementedInterfaces, _implementedInterfaces);
            template.Add(ClassTemplateAttributes.Fields, _fields);
            template.Add(ClassTemplateAttributes.Properties, _properties);
            template.Add(ClassTemplateAttributes.Constructors, _constructors);
            template.Add(ClassTemplateAttributes.Methods, _methods.Select(x => x.Render()));

            return template.Render();
        }
    }
}
