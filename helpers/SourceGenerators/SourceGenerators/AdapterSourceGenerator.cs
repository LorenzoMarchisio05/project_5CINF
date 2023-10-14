using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace SourceGenerators
{
    [Generator]
    public class AdapterSourceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var typesWithMyAttribute = context.SyntaxProvider
                      .CreateSyntaxProvider(CouldAttributeAsync, GetTypeOrNull)
                      .Where(type => type is not null)
                      .Collect();

            context.RegisterSourceOutput(typesWithMyAttribute, GenerateCode);
        }
        private static bool CouldAttributeAsync(SyntaxNode syntaxNode, CancellationToken cancellationToken)
        {
            if (syntaxNode is not AttributeSyntax attribute)
                return false;

            var name = ExtractName(attribute.Name);

            return name is "EnumGeneration" or "EnumGenerationAttribute";
        }

        private static string? ExtractName(NameSyntax? name)
        {
            return name switch
            {
                SimpleNameSyntax ins => ins.Identifier.Text,
                QualifiedNameSyntax qns => qns.Right.Identifier.Text,
                _ => null
            };
        }

        private static ITypeSymbol? GetTypeOrNull(GeneratorSyntaxContext context, CancellationToken cancellationToken)
        {
            var attributeSyntax = (AttributeSyntax)context.Node;

            // "attribute.Parent" is "AttributeListSyntax"
            // "attribute.Parent.Parent" is a C# fragment the attributes are applied to
            if (attributeSyntax.Parent?.Parent is not ClassDeclarationSyntax classDeclaration)
                return null;

            var type = context.SemanticModel.GetDeclaredSymbol(classDeclaration) as ITypeSymbol;

            return type is null || !IsEnumeration(type) ? null : type;
        }

        private static bool IsEnumeration(ISymbol type)
        {
            return type.GetAttributes()
                       .Any(a => a.AttributeClass?.Name == "AdapterAttribute" &&
                                 a.AttributeClass.ContainingNamespace is
                                 {
                                     Name: "SourceGenerators.Attributes",
                                 });
        }

        private static void GenerateCode(SourceProductionContext context, ImmutableArray<ITypeSymbol> enumerations)
        {
            if (enumerations.IsDefaultOrEmpty)
                return;

            var stringBuilder = new StringBuilder();
            var methodBuilder = new StringBuilder();

            foreach (var type in enumerations)
            {
                var code = GenerateCode(stringBuilder, methodBuilder, type);
                var typeNamespace = type.ContainingNamespace.IsGlobalNamespace
                       ? null
                       : $"{type.ContainingNamespace}.";

                context.AddSource($"{typeNamespace}{type.Name}.g.cs", code);
            }
        }

        private static string GenerateCode(StringBuilder stringBuilder, StringBuilder methodBuilder, ITypeSymbol type)
        {
            var ns = type.ContainingNamespace.IsGlobalNamespace
                ? null
                : type.ContainingNamespace.ToString();
            var typeName = type.Name;
            var propertyNames = GetItemNames(type);

            stringBuilder.Clear();

            stringBuilder.AppendLine($"namespace {ns} {{");
            stringBuilder.AppendLine($"public static class {typeName}Adapter {{");

            methodBuilder.Clear();
            // Adapt single
            methodBuilder.AppendLine($"public static {typeName} Adapt(System.Data.DataRowCollection row) {{");
            methodBuilder.AppendLine($"var obj = new {typeName}();");
            foreach (var propertyName in propertyNames)
            {
                methodBuilder.Append($"obj.{propertyName} = ");
                methodBuilder.AppendLine($"row[\"{propertyName}\"]");
            }
            methodBuilder.AppendLine("return obj;");
            methodBuilder.AppendLine("}");
            // End Adapt single

            methodBuilder.AppendLine("");

            // Adapt multi
            methodBuilder.AppendLine($"public static System.Collections.Generic.IEnumerable<{typeName}> Adapt(System.Data.DataTable dataTable) {{");
            methodBuilder.AppendLine("var array = new {type.Name}[dataTable.Rows.Count];");
            methodBuilder.AppendLine("var i = 0;");
            methodBuilder.AppendLine("foreach(DataRowCollection row in dataTable) {");
            methodBuilder.AppendLine("array[i] = Adapt(row);");
            methodBuilder.AppendLine("i++;");
            methodBuilder.AppendLine("}");
            methodBuilder.AppendLine("return array;");
            methodBuilder.AppendLine("}");
            // End Adapt multi

            stringBuilder.Append(methodBuilder.ToString());

            // class closing
            stringBuilder.AppendLine("}");
            // namespace closing
            stringBuilder.AppendLine("}");

            return stringBuilder.ToString();
        }

        private static IEnumerable<string?> GetItemNames(ITypeSymbol type)
        {
            return type.GetMembers()
                       .Select(m =>
                       {
                           if(m.IsStatic)
                           {
                               return null;
                           }

                           if(m.DeclaredAccessibility != Accessibility.Public)
                           {
                               return null;
                           }

                           if(m is not IFieldSymbol field)
                           {
                               return null;
                           }

                           return SymbolEqualityComparer.Default.Equals(field.Type, type)
                            ? field.Name
                            : null;
                       })
                       .Where(field => field is not null);
        }

    }
}
