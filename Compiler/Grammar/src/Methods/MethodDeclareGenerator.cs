using Compiler.Grammar.model;

namespace Compiler.Grammar.src.Methods;

public class MethodDeclareGenerator
{
    public static string DeclareMethod(string id, VariableType? type)
    {
        return "define " + Util.Util.MapType(type) + " @" + id + "(";
    }

    public static string ParseParameters(Variable[] parameters)
    {
        var parametersStr = "";
        foreach (var parameter in parameters)
        {
            parametersStr += Util.Util.MapType(parameter.Type) + " %" + parameter.Id + ", ";
        }

        return parametersStr.Remove(parametersStr.Length - 2) + ")\n {";
    }
    
    public static string Return(string id, VariableType? type)
    {
        if (type == null)
        {
            return "ret void\n";
        }
        
        return "ret " + Util.Util.MapType(type) + " %" + id + "\n";
    }
    
    public static string EndMethod()
    {
        return "}\n";
    }
}