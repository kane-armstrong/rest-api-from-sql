using Antlr4.StringTemplate;
using CodeGenerator.Templates;
using CodeGenerator.Templates.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeGenerator
{
    // TODO use source generators instead
    public class ClassBuilder
    {
        private const char StartDelimiter = '$';
        private const char EndDelimiter = '$';

        // TODO Tidy up regex - probably don't need two sets, try do whitespace check and first char check in one regex
        private static readonly Regex LegalNamespaceCharacters = new("[a-zA-Z\\d_]");
        private static readonly Regex LegalNamespaceLeadingCharacters = new("^[a-zA-Z_]");

        private static readonly Regex LegalClassNameCharacters = new("^[a-zA-Z\\d_]");
        private static readonly Regex LegalClassNameLeadingCharacters = new("^[a-zA-Z_]");

        private string _namespace;
        private string _className;

        private readonly List<string> _usingDirectives = new();

        public ClassBuilder WithNamespace(string value)
        {
            if (string.IsNullOrEmpty(value)
                || !LegalNamespaceCharacters.IsMatch(value)
                || !LegalNamespaceLeadingCharacters.IsMatch(value[..1])
                || value.Contains(" "))
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
                || !LegalNamespaceLeadingCharacters.IsMatch(value[..1])
                || value.Contains(" "))
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

        public ClassBuilder WithName(string value)
        {
            if (string.IsNullOrEmpty(value)
                || !LegalClassNameCharacters.IsMatch(value)
                || !LegalClassNameLeadingCharacters.IsMatch(value[..1])
                || value.Contains(" "))
            {
                throw new InvalidOperationException("Invalid class name");
            }
            _className = value;
            return this;
        }

        public ClassBuilder WithMethod(string definition)
        {

            return this;
        }

        public ClassBuilder WithProperty(string definition)
        {
            return this;
        }

        public ClassBuilder WithClassAnnotation(string definition)
        {
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
            
            var template = new Template(TemplateContent.Class, StartDelimiter, EndDelimiter);
            
            template.Add(SharedTemplateKeys.ClassNamespace, _namespace);
            template.Add(SharedTemplateKeys.ClassName, _className);

            var sb = new StringBuilder();
            foreach (var usingDirective in _usingDirectives)
            {
                sb.AppendLine($"using {usingDirective};");
            }
            template.Add(SharedTemplateKeys.UsingDirectives, sb.ToString());

            return template.Render();
        }
    }
}
