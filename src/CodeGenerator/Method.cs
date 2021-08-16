using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.StringTemplate;
using CodeGenerator.Templates;
using CodeGenerator.Templates.Resources;

namespace CodeGenerator
{
    public class Method
    {
        private const char StartDelimiter = '$';
        private const char EndDelimiter = '$';

        private static readonly Dictionary<MethodAccessibilityLevel, string> MethodAccessibilityLevelMap = new()
        {
            { MethodAccessibilityLevel.Internal, "internal" },
            { MethodAccessibilityLevel.Public, "public" },
            { MethodAccessibilityLevel.Private, "private" },
            { MethodAccessibilityLevel.PrivateProtected, "private protected" },
            { MethodAccessibilityLevel.Protected, "protected" },
            { MethodAccessibilityLevel.ProtectedInternal, "protected internal" }
        };

        private static readonly string[] Modifiers =
        {
            "abstract",
            "async",
            "new",
            "override",
            "sealed",
            "static",
            "virtual"
        };

        private readonly List<string> _attributes = new();
        private readonly MethodAccessibilityLevel _accessibilityLevel;
        private readonly string _returnType;
        private readonly string _name;
        private readonly string _body;
        private readonly List<MethodArgument> _arguments = new();
        private readonly List<string> _modifiers = new();

        public Method(MethodAccessibilityLevel? accessibilityLevel, string returnType, string name, string body = null)
        {
            _accessibilityLevel = accessibilityLevel ?? throw new ArgumentNullException(nameof(accessibilityLevel));
            _returnType = returnType ?? throw new ArgumentNullException(nameof(returnType));
            _name = name ?? throw new ArgumentNullException(nameof(name));
            _body = body;
        }

        public void AddArgument(MethodArgument argument)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(nameof(argument));
            }

            if (_arguments.Any(x => x.Name == argument.Name))
            {
                throw new InvalidOperationException("Argument with the same name already been added.");
            }

            _arguments.Add(argument);
        }

        public void AddModifier(string value)
        {
            if (!Modifiers.Contains(value))
            {
                throw new ArgumentException($"The modifier '{value}' cannot be applied to methods.");
            }

            if (_body != null && value == "abstract")
            {
                throw new InvalidOperationException("Method can't be marked abstract as it has a body.");
            }

            if (value == "sealed" && !_modifiers.Contains("override"))
            {
                throw new InvalidOperationException("Method can't be marked sealed as it is not an override.");
            }

            _modifiers.Add(value);
        }

        public string Render()
        {
            var template = new Template(TemplateContent.Method, StartDelimiter, EndDelimiter);

            template.Add(MethodTemplateAttributes.AccessibilityLevel, MethodAccessibilityLevelMap[_accessibilityLevel]);
            template.Add(MethodTemplateAttributes.Modifiers, _modifiers);
            template.Add(MethodTemplateAttributes.ReturnType, _returnType);
            template.Add(MethodTemplateAttributes.Name, _name);
            template.Add(MethodTemplateAttributes.Body, _body);
            template.Add(MethodTemplateAttributes.Arguments, _arguments);
            template.Add(MethodTemplateAttributes.IsAbstract, _modifiers.FirstOrDefault(x => x == "abstract"));

            return template.Render();
        }
    }
}
