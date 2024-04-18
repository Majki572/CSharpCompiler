using Compiler.Grammar.model;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src.Actions;

public class ReadGenerator
{
    public static string Read(Variable variable)
    {
        var res = "";
        switch (variable.Type)
        {
            case VariableType.SHORT:
                res += ShortGenerator.ReadShort(variable.GetId());
                break;
            case VariableType.INT:
                res += IntegerGenerator.ReadInteger(variable.GetId());
                break;
            case VariableType.LOGNLONG:
                res += LongGenerator.ReadLong(variable.GetId());
                break;
            case VariableType.FLOAT:
                res += FloatGenerator.ReadFloat(variable.GetId());
                break;
            case VariableType.DOUBLE:
                res += DoubleGenerator.ReadDouble(variable.GetId());
                break;
            case VariableType.BOOL:
                res += BoolGenerator.ReadBool(variable.GetId());
                break;
            case VariableType.STRING:
                res += StringGenerator.LoadString(variable.GetId());
                res += StringGenerator.ReadString(Generator.GetReg(1));
                break;
        }
        
        return res;
    }
}