using Antlr4.StringTemplate;
using CodeGenerator.Templates;
using CodeGenerator.Templates.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CodeGenerator
{
    public class MethodDefinitionBuilder
    {
        private const char StartDelimiter = '$';
        private const char EndDelimiter = '$';

        private static readonly Dictionary<MethodAccessibilityLevel, string> MethodAccessibilityLevelMap = new()
        {
            {MethodAccessibilityLevel.Internal, "internal"},
            {MethodAccessibilityLevel.Public, "public"},
            {MethodAccessibilityLevel.Private, "private"},
            {MethodAccessibilityLevel.PrivateProtected, "private protected"},
            {MethodAccessibilityLevel.Protected, "protected"},
            {MethodAccessibilityLevel.ProtectedInternal, "protected internal"}
        };

        private MethodAccessibilityLevel? _accessibilityLevel;
        private string _returnType;
        private string _name;
        private string _body;
        private readonly List<MethodArgument> _arguments = new();

        public MethodDefinitionBuilder WithAccessibilityLevel(MethodAccessibilityLevel accessibilityLevel)
        {
            _accessibilityLevel = accessibilityLevel;
            return this;
        }

        public MethodDefinitionBuilder WithReturnType(string value)
        {
            _returnType = value;
            return this;
        }

        public MethodDefinitionBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public MethodDefinitionBuilder WithArgument(MethodArgument argument)
        {
            _arguments.Add(argument);
            return this;
        }

        public MethodDefinitionBuilder WithBody(string body)
        {
            _body = body;
            return this;
        }

        public string Build()
        {
            if (_accessibilityLevel == null)
            {
                throw new InvalidOperationException("An access modifier is required");
            }
            if (_returnType == null)
            {
                throw new InvalidOperationException("A return type is required");
            }
            if (_name == null)
            {
                throw new InvalidOperationException("A name is required");
            }

            var template = new Template(TemplateContent.Method, StartDelimiter, EndDelimiter);

            template.Add(MethodTemplateAttributes.AccessibilityLevel, MethodAccessibilityLevelMap[_accessibilityLevel.Value]);
            template.Add(MethodTemplateAttributes.ReturnType, _returnType);
            template.Add(MethodTemplateAttributes.Name, _name);
            template.Add(MethodTemplateAttributes.Body, _body);

            // TODO this belongs in the template
            var args = string.Join(", ", _arguments.Select(x => $"{x.Type} {x.Name}"));
            template.Add(MethodTemplateAttributes.Arguments, args);

            return template.Render();
        }
    }
}
