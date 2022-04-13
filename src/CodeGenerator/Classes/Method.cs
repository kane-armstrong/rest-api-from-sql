using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Antlr4.StringTemplate;
using CodeGenerator.Classes.Templates;
using CodeGenerator.Classes.Templates.Resources;

[assembly: InternalsVisibleTo("CodeGenerator.Tests")]
namespace CodeGenerator.Classes;

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

    private static readonly string[] AllowedModifiers =
    {
        "abstract",
        "async",
        "new",
        "override",
        "sealed",
        "static",
        "virtual"
    };

    private readonly List<MethodArgument> _arguments = new();
    private readonly List<string> _modifiers = new();
    private readonly List<string> _attributes = new();

    public IReadOnlyList<string> Attributes => _attributes.AsReadOnly();
    public MethodAccessibilityLevel AccessibilityLevel { get; }
    public string ReturnType { get; }
    public string Name { get; }
    public string Body { get; }
    public IReadOnlyList<MethodArgument> Arguments => _arguments.AsReadOnly();
    public IReadOnlyList<string> Modifiers => _modifiers.AsReadOnly();

    public Method(MethodAccessibilityLevel? accessibilityLevel, string returnType, string name, string body = null)
    {
        AccessibilityLevel = accessibilityLevel ?? throw new ArgumentNullException(nameof(accessibilityLevel));
        ReturnType = returnType ?? throw new ArgumentNullException(nameof(returnType));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Body = body;
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
        if (!AllowedModifiers.Contains(value))
        {
            throw new ArgumentException($"The modifier '{value}' cannot be applied to methods.");
        }

        if (Body != null && value == "abstract")
        {
            throw new InvalidOperationException("Method can't be marked abstract as it has a body.");
        }

        if (value == "sealed" && !_modifiers.Contains("override"))
        {
            throw new InvalidOperationException("Method can't be marked sealed as it is not an override.");
        }

        _modifiers.Add(value);
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

    internal string Render()
    {
        var template = new Template(TemplateContent.Method, StartDelimiter, EndDelimiter);

        template.Add(MethodTemplateAttributes.AccessibilityLevel, MethodAccessibilityLevelMap[AccessibilityLevel]);
        template.Add(MethodTemplateAttributes.Modifiers, _modifiers);
        template.Add(MethodTemplateAttributes.ReturnType, ReturnType);
        template.Add(MethodTemplateAttributes.Name, Name);
        template.Add(MethodTemplateAttributes.Body, Body);
        template.Add(MethodTemplateAttributes.Arguments, _arguments);
        template.Add(MethodTemplateAttributes.Attributes, _attributes);
        template.Add(MethodTemplateAttributes.IsAbstract, _modifiers.FirstOrDefault(x => x == "abstract"));

        return template.Render();
    }
}