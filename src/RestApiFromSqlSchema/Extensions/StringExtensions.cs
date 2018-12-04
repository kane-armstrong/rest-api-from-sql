namespace Armsoft.RestApiFromSqlSchema.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCase(this string obj)
        {
            if (obj.Length == 1)
            {
                return obj.ToLowerInvariant();
            }
            if (obj.Length > 1)
            {
                return char.ToLowerInvariant(obj[0]) + obj.Substring(1);
            }
            return obj;
        }
    }
}