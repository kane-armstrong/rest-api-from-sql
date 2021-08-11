using Antlr4.StringTemplate;
using CodeGenerator.Templates;
using CodeGenerator.Templates.Resources;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeGenerator
{
    public class MethodDefinitionBuilder
    {
        private const char StartDelimiter = '$';
        private const char EndDelimiter = '$';

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

            template.Add(SharedTemplateKeys.MethodAccessibilityLevel, _accessibilityLevel.ToString().ToLowerInvariant());
            template.Add(SharedTemplateKeys.MethodReturnType, _returnType);
            template.Add(SharedTemplateKeys.MethodName, _name);
            template.Add(SharedTemplateKeys.MethodBody, _body);

            var args = string.Join(", ", _arguments.Select(x => $"{x.Type} {x.Name}"));
            template.Add(SharedTemplateKeys.MethodArguments, args);

            return template.Render();
        }
    }
}
