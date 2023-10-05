namespace SourceGenerators.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Field | System.AttributeTargets.Property, AllowMultiple = true)]
    public class SqlParamAttribute : System.Attribute
    {
        public string Name { get; }

        public SqlParamAttribute(string name) => this.Name = name;
    }
}