namespace Armsoft.RestApiFromSqlSchema.Rendering
{
    internal class IdentifierConfiguration
    {
        internal string Identifier { get; }
        internal string Predicate { get; }

        internal IdentifierConfiguration(string identifier, string predicate)
        {
            Identifier = identifier;
            Predicate = predicate;
        }
    }
}