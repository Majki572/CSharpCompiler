using Compiler.Grammar.model;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src.Actions.Compare;

public class GraterEqualThanGenerator
{
    public static string GraterEqualThan(Variable var1, Variable var2)
    {
        var res = "";
        switch (var1.Type) 
        {
            case VariableType.SHORT:
                res += ShortGenerator.GreaterThanOrEqualShort(var1.GetId(), var2.GetId());
                break;
            case VariableType.INT:
                res += IntegerGenerator.GreaterThanOrEqualInteger(var1.GetId(), var2.GetId());
                break;
            case VariableType.LOGNLONG:
                res += LongGenerator.GreaterThanOrEqualLong(var1.GetId(), var2.GetId());
                break;
            case VariableType.FLOAT:
                res += FloatGenerator.GeFloat(var1.GetId(), var2.GetId());
                break;
            case VariableType.DOUBLE:
                res += DoubleGenerator.GeDouble(var1.GetId(), var2.GetId());
                break;
        }

        return res;
    }
}