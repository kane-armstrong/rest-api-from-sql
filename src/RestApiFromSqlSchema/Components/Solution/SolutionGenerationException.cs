using System;

namespace RestApiFromSqlSchema.Components.Solution
{
    public class SolutionGenerationException : Exception
    {
        public SolutionGenerationException(string message) : base(message)
        {
        }

        public SolutionGenerationException(string message, Exception e) : base(message, e)
        {
        }
    }
}