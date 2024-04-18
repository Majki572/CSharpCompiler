using Compiler.Grammar.model;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src.Actions.Compare;

public class LessEqualThanGenerator
{
    public static string LessEqualThan(Variable var1, Variable var2)
    {
        var res = "";
        switch (var1.Type) 
        {
            case VariableType.SHORT:
                res += ShortGenerator.LessThanOrEqualShort(var1.GetId(), var2.GetId());
                break;
            case VariableType.INT:
                res += IntegerGenerator.LessThanOrEqualInteger(var1.GetId(), var2.GetId());
                break;
            case VariableType.LOGNLONG:
                res += LongGenerator.LessThanOrEqualLong(var1.GetId(), var2.GetId());
                break;
            case VariableType.FLOAT:
                res += FloatGenerator.LeFloat(var1.GetId(), var2.GetId());
                break;
            case VariableType.DOUBLE:
                res += DoubleGenerator.LeDouble(var1.GetId(), var2.GetId());
                break;
        }

        return res;
    }
}