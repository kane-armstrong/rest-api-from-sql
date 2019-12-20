using System;
using RestApiFromSqlSchema.Components.Solution.Global.Enumerations;

namespace RestApiFromSqlSchema.Components.Solution.Global.Sections
{
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
}