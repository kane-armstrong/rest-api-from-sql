using System;

namespace CodeGenerator.Solutions
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