namespace SchemaExplorer.Experimental
{
    public class Constraint
    {
        public string ConstraintCatalog { get; set; }
        public string Name { get; set; }
        public ConstraintType ConstraintType { get; set; }
        public int OrdinalPosition { get; set; }
    }
}