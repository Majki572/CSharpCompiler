using Compiler.Grammar.model;
using Compiler.Grammar.src.Actions;

namespace Compiler.Grammar.src.Methods;

public class MethodDeclareGenerator
{
    public static string DeclareMethod(string id, VariableType? type)
    {
        return "define " + Util.Util.MapType(type) + " " + id + "(";
    }

    public static string ParseParameters(Variable[] parameters)
    {
        if (parameters.Length == 0)
        {
            return ") {\n";
        }

        var res = "";
        
        var parametersStr = "";
        int i = 0;
        foreach (var parameter in parameters)
        {
            parametersStr += Util.Util.MapType(parameter.Type) + " " + Generator.GetRegInc() + ", ";
        }

        res += parametersStr.Remove(parametersStr.Length - 2) + ") {\n";
        
        foreach (var parameter in parameters)
        {
            res += DeclareGenerator.Declare(parameter, new Variable( "%" + i, parameter.Type));
            i++;
        }

        return res;
    }
    
    public static string Return(string id, VariableType? type)
    {
        if (type == null)
        {
            return "ret void\n";
        }
        
        return "ret " + Util.Util.MapType(type) + " " + id + "\n";
    }
    
    public static string EndMethod()
    {
        return "}\n";
    }
}