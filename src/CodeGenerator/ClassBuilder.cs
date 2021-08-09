using System;
using System.Text.RegularExpressions;
using Antlr4.StringTemplate;
using CodeGenerator.Templates;
using CodeGenerator.Templates.Resources;

namespace CodeGenerator
{
    // TODO use source generators instead
    public class ClassBuilder
    {
        private const char StartDelimiter = '$';
        private const char EndDelimiter = '$';

        private static readonly Regex LegalNamespaceCharacters = new("[a-zA-Z\\d_]");
        private static readonly Regex LegalNamespaceLeadingCharacters = new("[a-zA-Z_]");

        private string _namespace;

        public ClassBuilder WithNamespace(string value)
        {
            if (string.IsNullOrEmpty(value) 
                || !LegalNamespaceCharacters.IsMatch(value) 
                || !LegalNamespaceLeadingCharacters.IsMatch(value.Substring(0, 1)))
            {
                throw new InvalidOperationException("Invalid namespace");
            }
            _namespace = value;
            return this;
        }

        public ClassBuilder WithUsingDirective(string namespaceValue)
        {
            return this;
        }

        public ClassBuilder WithName(string value)
        {
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

        public string Build()
        {
            if (_namespace == null)
            {
                throw new InvalidOperationException("A namespace is required");
            }
            var template = new Template(TemplateContent.Class, StartDelimiter, EndDelimiter);
            template.Add(SharedTemplateKeys.ClassNamespace, _namespace);
            return template.Render();
        }
    }
}
