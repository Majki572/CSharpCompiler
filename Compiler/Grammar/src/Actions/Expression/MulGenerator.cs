using Compiler.Grammar.model;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src.Actions.Expression;

public class MulGenerator
{
    public static string Mul(Variable var1, Variable var2)
    {
        var res = "";
        switch (var1.Type) 
        {
            case VariableType.SHORT:
                res += ShortGenerator.MulShort(var1.GetId(), var2.GetId());
                break;
            case VariableType.INT:
                res += IntegerGenerator.MulInteger(var1.GetId(), var2.GetId());
                break;
            case VariableType.LOGNLONG:
                res += LongGenerator.MulLong(var1.GetId(), var2.GetId());
                break;
            case VariableType.FLOAT:
                res += FloatGenerator.MulFloat(var1.GetId(), var2.GetId());
                break;
            case VariableType.DOUBLE:
                res += DoubleGenerator.MulDouble(var1.GetId(), var2.GetId());
                break;
        }

        return res;
    }
}