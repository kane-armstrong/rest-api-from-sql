using System.Text.RegularExpressions;

namespace RestApiFromSqlSchema.SqlServer.Internal
{
    internal static class StringExtensions
    {
        private static readonly Regex NonAlphanumericRegex = new Regex("[^a-zA-Z0-9]");
        private static readonly Regex NumberRegex = new Regex("[0-9]");
        private const string EscapeCharacter = "_";

        internal static string EscapeIllegalCsharpClassSymbols(this string obj)
        {
            var result = obj;
            var firstCharacterIsIllegalChar = NumberRegex.Match(obj.Substring(0, 1)).Success;
            if (firstCharacterIsIllegalChar)
            {
                result = EscapeCharacter + result;
            }
            return NonAlphanumericRegex.Replace(result, EscapeCharacter);
        }
    }
}