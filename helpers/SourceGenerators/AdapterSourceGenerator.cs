﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SourceGenerators
{
    [Generator]
    public class AdapterSourceGenerator : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var typesWithMyAttribute =
                from a in AppDomain.CurrentDomain.GetAssemblies().AsParallel()
                from t in a.GetTypes()
                let attributes = t.GetCustomAttributes(typeof(SourceGenerators.Attributes.AdapterAttribute), true)
                where attributes != null && attributes.Length > 0
                select new { Type = t, Attributes = attributes.Cast<SourceGenerators.Attributes.AdapterAttribute>() };

            var stringBuilder = new StringBuilder();
            var methodBuilder = new StringBuilder();

            foreach (var data in typesWithMyAttribute)
            {
                var type = data.Type;

                var properties = from PropertyInfo property
                                 in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                 where 
                                    property.GetCustomAttributes(typeof(SourceGenerators.Attributes.SqlParamAttribute), true).Length > 0
                                 select property;

                stringBuilder.Clear();

                stringBuilder.AppendLine("namespace GenerateCode {");
                stringBuilder.AppendLine($"public static class {type.Name} {{");

                methodBuilder.Clear();
                methodBuilder.AppendLine($"public static {type.Name} Adapt(System.Data.DataRowCollection row) {{");
                methodBuilder.AppendLine($"var obj = new {type.Name}();");

                foreach(var property in properties)
                {
                    methodBuilder.Append($"obj.{property.Name} = ");
                    methodBuilder.AppendLine($"row[\"{property.Name}\"]");
                }

                methodBuilder.AppendLine("return obj;");
                methodBuilder.AppendLine("}");

                methodBuilder.AppendLine("");
                methodBuilder.AppendLine($"public static System.Collections.Generic.IEnumerable<{type.Name}> Adapt(System.Data.DataTable dataTable) {{");
                methodBuilder.AppendLine("var array = new {type.Name}[dataTable.Rows.Count];");
                methodBuilder.AppendLine("var i = 0;");
                methodBuilder.AppendLine("foreach(DataRowCollection row in dataTable) {");
                methodBuilder.AppendLine("array[i] = Adapt(row);");
                methodBuilder.AppendLine("i++;");
                methodBuilder.AppendLine("}");
                methodBuilder.AppendLine("return array;");
                methodBuilder.AppendLine("}");

                stringBuilder.Append(methodBuilder.ToString());
                
                stringBuilder.AppendLine("}");
                stringBuilder.AppendLine("}");

                context.RegisterPostInitializationOutput(ctx =>
                {
                    ctx.AddSource($"{type.Name}.g.cs", SourceText.From(stringBuilder.ToString(), Encoding.UTF8));
                });
            }
        }
    }
}
