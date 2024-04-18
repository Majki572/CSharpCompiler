using Compiler.Grammar.model;

namespace Compiler.Grammar.src.Methods;

public class MethodCallGenerator
{
    // id shod be with @id
    public static string CallMethod(string id, VariableType? type, Variable[] parameters)
    {
        var call = "call " + Util.Util.MapType(type) + " " + id + "(";
        foreach (var parameter in parameters)
        {
            call += Util.Util.MapType(parameter.Type) + " %" + parameter.Id + ", ";
        }

        return call.Remove(call.Length - 2) + ")";
    }
}