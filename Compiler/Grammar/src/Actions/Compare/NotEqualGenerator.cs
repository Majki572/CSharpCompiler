using Compiler.Grammar.model;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src.Actions.Compare;

public class NotEqualGenerator
{
    public static string NotEqual(Variable var1, Variable var2)
    {
        var res = "";
        switch (var1.Type) 
        {
            case VariableType.SHORT:
                res += ShortGenerator.NotEqualShort(var1.GetId(), var2.GetId());
                break;
            case VariableType.INT:
                res += IntegerGenerator.NotEqualInteger(var1.GetId(), var2.GetId());
                break;
            case VariableType.LOGNLONG:
                res += LongGenerator.NotEqualLong(var1.GetId(), var2.GetId());
                break;
            case VariableType.FLOAT:
                res += FloatGenerator.NeFloat(var1.GetId(), var2.GetId());
                break;
            case VariableType.DOUBLE:
                res += DoubleGenerator.NeDouble(var1.GetId(), var2.GetId());
                break;
            case VariableType.BOOL:
                res += BoolGenerator.NotEqualBool(var1.GetId(), var2.GetId());
                break;
        }

        return res;
    }
}