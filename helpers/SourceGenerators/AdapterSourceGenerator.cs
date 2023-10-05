using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Linq;
using System.Text;

namespace SourceGenerators
{
    [Generator]
    public class AdapterSourceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            /*
            context.RegisterPostInitializationOutput(ctx =>
            {
                var sourceText = $$"""
                    namespace SourceGeneratorInCSharp
                    {
                        public static class HelloWorld
                        {
                            public static void SayHello()
                            {
                                Console.WriteLine("Hello From Generator");
                            }
                        }
                    }
                    """;
                ctx.AddSource("ExampleGenerator.g", SourceText.From(sourceText, Encoding.UTF8));
            });
            */

            var typesWithMyAttribute =
                from a in AppDomain.CurrentDomain.GetAssemblies().AsParallel()
                from t in a.GetTypes()
                let attributes = t.GetCustomAttributes(typeof(SourceGenerators.Attributes.AdapterAttribute), true)
                where attributes != null && attributes.Length > 0
                select new { Type = t, Attributes = attributes.Cast<SourceGenerators.Attributes.AdapterAttribute>() };
            
            foreach (var type in typesWithMyAttribute)
            {

            }
        }
    }
}
