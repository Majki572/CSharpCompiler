using Compiler.Grammar.model;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src.Actions.Compare;

public class EqualGenerator
{
    public static string Equal(Variable var1, Variable var2)
    {
        var res = "";
        switch (var1.Type) 
        {
            case VariableType.SHORT:
                res += ShortGenerator.EqualShort(var1.GetId(), var2.GetId());
                break;
            case VariableType.INT:
                res += IntegerGenerator.EqualInteger(var1.GetId(), var2.GetId());
                break;
            case VariableType.LOGNLONG:
                res += LongGenerator.EqualLong(var1.GetId(), var2.GetId());
                break;
            case VariableType.FLOAT:
                res += FloatGenerator.EqualFloat(var1.GetId(), var2.GetId());
                break;
            case VariableType.DOUBLE:
                res += DoubleGenerator.EqualDouble(var1.GetId(), var2.GetId());
                break;
            case VariableType.BOOL:
                res += BoolGenerator.EqualBool(var1.GetId(), var2.GetId());
                break;
            case VariableType.STRING:
                res += StringGenerator.EqualString(var1.GetId(), var2.GetId());
                break;
            case VariableType.STRING_CONST:
                res += StringGenerator.EqualString(var1.GetId(), var2.GetId());
                break;
        }

        return res;
    }
}