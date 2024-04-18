using Compiler.Grammar.model;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src.Actions;

public class PrintGenerator
{
    public static string Print(Variable variable)
    {
        var res = "";
        switch (variable.Type)
        {
            case VariableType.SHORT:
                res += ShortGenerator.PrintShort(variable.GetId());
                break;
            case VariableType.INT:
                res += IntegerGenerator.PrintInteger(variable.GetId());
                break;
            case VariableType.LOGNLONG:
                res += LongGenerator.PrintLong(variable.GetId());
                break;
            case VariableType.FLOAT:
                res += FloatGenerator.PrintFloat(variable.GetId());
                break;
            case VariableType.DOUBLE:
                res += DoubleGenerator.PrintDouble(variable.GetId());
                break;
            case VariableType.BOOL:
                res += BoolGenerator.PrintBool(variable.GetId());
                break;
            case VariableType.STRING:
                res += StringGenerator.PrintString(variable.GetId());
                break;
            case VariableType.STRING_CONST:
                res += StringGenerator.PrintString(StringGenerator.GetConstString(variable as StringVariable));
                break;
        }
        
        return res;
    }
}