using Compiler.Grammar.model;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src.Actions;

public class LoadVariableGenerator
{
    public static string LoadVariable(Variable variable)
    {
        var res = "";
        switch (variable.Type)
        {
            case VariableType.SHORT:
                res += ShortGenerator.LoadShort(variable.GetId());
                res += ShortGenerator.MapShort(Generator.GetReg(1));
                break;
            case VariableType.INT:
                res += IntegerGenerator.LoadInteger(variable.GetId());
                break;
            case VariableType.LOGNLONG:
                res += LongGenerator.LoadLong(variable.GetId());
                break;
            case VariableType.FLOAT:
                res += FloatGenerator.LoadFloat(variable.GetId());
                break;
            case VariableType.DOUBLE:
                res += DoubleGenerator.LoadDouble(variable.GetId());
                break;
            case VariableType.BOOL:
                res += BoolGenerator.LoadBool(variable.GetId());
                break;
            case VariableType.STRING or VariableType.STRING_CONST:
                res += StringGenerator.LoadString(variable.GetId());
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        return res;
    }
}