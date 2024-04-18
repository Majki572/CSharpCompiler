using Compiler.Grammar.model;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src.Actions.Compare;

public class LessThanGenerator
{
    public static string LessThan(Variable var1, Variable var2)
    {
        var res = "";
        switch (var1.Type) 
        {
            case VariableType.SHORT:
                res += ShortGenerator.LessThanShort(var1.GetId(), var2.GetId());
                break;
            case VariableType.INT:
                res += IntegerGenerator.LessThanInteger(var1.GetId(), var2.GetId());
                break;
            case VariableType.LOGNLONG:
                res += LongGenerator.LessThanLong(var1.GetId(), var2.GetId());
                break;
            case VariableType.FLOAT:
                res += FloatGenerator.LtFloat(var1.GetId(), var2.GetId());
                break;
            case VariableType.DOUBLE:
                res += DoubleGenerator.LtDouble(var1.GetId(), var2.GetId());
                break;
        }

        return res;
    }
}