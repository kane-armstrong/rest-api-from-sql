using System;
using CodeGenerator.Solutions.Global.Enumerations;

namespace CodeGenerator.Solutions.Global.Sections;

public class ExtensibilityGlobals
{
    internal const string GlobalSectionId = "ExtensibilityGlobals";
    internal static readonly GlobalSectionType GlobalSectionType = GlobalSectionType.postSolution;

    public Guid SolutionGuid { get; }

    public ExtensibilityGlobals(Guid solutionGuid)
    {
        SolutionGuid = solutionGuid;
    }

    public override string ToString()
    {
        return $"{nameof(SolutionGuid)} = {{{SolutionGuid.ToString().ToUpper()}}}";
    }
}