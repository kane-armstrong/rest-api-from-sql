namespace Armsoft.RestApiFromSqlSchema
{
    public class Name
    {
        public string ActualName { get; }
        public string LegalCsharpName { get; }

        public Name(string actualName, string legalCsharpName)
        {
            ActualName = actualName;
            LegalCsharpName = legalCsharpName;
        }
    }
}