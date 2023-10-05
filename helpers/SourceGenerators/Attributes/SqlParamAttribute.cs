namespace SourceGenerators.Attributes
{
    [System.AttributeUsage(System.AttributeTargets.Field, AllowMultiple = true)]
    public class SqlParamAttribute : System.Attribute
    {
        public string Name { get; }

        public SqlParamAttribute(string name) => this.Name = name;
    }
}
