namespace Armsoft.RestApiFromSqlSchema.Components.Schema
{
    public class Column
    {
        public Name Name { get; set; }
        public int Order { get; }
        public bool AllowsNulls { get; }
        public string DataType { get; }

        public string ActualName => Name.ActualName;
        public string LegalCsharpName => Name.LegalCsharpName;

        public Column(Name name, int order, bool allowsNulls, string dataType)
        {
            Name = name;
            Order = order;
            AllowsNulls = allowsNulls;
            DataType = dataType;
        }
    }
}