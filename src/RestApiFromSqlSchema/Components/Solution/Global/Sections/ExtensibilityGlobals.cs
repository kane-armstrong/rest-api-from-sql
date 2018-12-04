using System;
using Armsoft.RestApiFromSqlSchema.Components.Solution.Global.Enumerations;

namespace Armsoft.RestApiFromSqlSchema.Components.Solution.Global.Sections
{
    public class ExtensibilityGlobals
    {
        internal static string GlobalSectionId = "ExtensibilityGlobals";
        internal static GlobalSectionType GlobalSectionType = GlobalSectionType.postSolution;

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