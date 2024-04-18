using Compiler.Grammar.model;

namespace Compiler.Grammar.src.Structs;

public class StructDeclareGenerator
{
    public static string DeclareStruct(string id)
    {
        return id + " = type { ";
    }
    
    public static string DeclareStructFields(string id, Variable[] fields)
    {
        var fieldsStr = "";
        foreach (var field in fields)
        {
            fieldsStr += Util.Util.MapType(field) + ", ";
        }

        return fieldsStr.Remove(fieldsStr.Length - 2) + " }\n";
    }
}