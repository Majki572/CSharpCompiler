using Compiler.Grammar.model;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src.Actions;

public class DeclareGenerator
{
    public static string Declare(Variable variable, Variable value)
    {
        var res = "";
        switch (variable.Type)
        {
            case VariableType.SHORT:
                res += ShortGenerator.AllocateShort(variable.GetId());
                res += ShortGenerator.AssignShort(variable.GetId(), value.GetId());
                break;
            case VariableType.INT:
                res += IntegerGenerator.AllocateInteger(variable.GetId());
                res += IntegerGenerator.AssignInteger(variable.GetId(), value.GetId());
                break;
            case VariableType.LOGNLONG:
                res += LongGenerator.AllocateLong(variable.GetId());
                res += LongGenerator.AssignLong(variable.GetId(), value.GetId());
                break;
            case VariableType.FLOAT:
                res += FloatGenerator.AllocateFloat(variable.GetId());
                res += FloatGenerator.AssignFloat(variable.GetId(), value.GetId());
                break;
            case VariableType.DOUBLE:
                res += DoubleGenerator.AllocateDouble(variable.GetId());
                res += DoubleGenerator.AssignDouble(variable.GetId(), value.GetId());
                break;
            case VariableType.BOOL:
                res += BoolGenerator.AllocateBool(variable.GetId());
                var boolValue = value.GetId();
                if (boolValue.Equals("true"))
                {
                    res += BoolGenerator.AssignBool(variable.GetId(), "1");
                }
                else
                {
                    res += BoolGenerator.AssignBool(variable.GetId(), "0");
                }
                break;
            case VariableType.STRING or VariableType.STRING_CONST:
                if (variable is StringVariable stringVariable)
                {
                    res += StringGenerator.AllocateString(stringVariable.GetId());
                    res += StringGenerator.AllocateStringSize(stringVariable.GetId(), stringVariable.Length);
                    res += StringGenerator.LoadString(stringVariable.GetId());
                    if (value.Type == VariableType.STRING_CONST && value is StringVariable valueVariable)
                    {
                        res += StringGenerator.AssignConstantString(Generator.GetReg(1), value.GetId(), valueVariable.Length);
                    }
                    else
                    {
                        res += StringGenerator.AssignString(Generator.GetReg(1), value.GetId());
                    }
                }
                else
                {
                    Console.WriteLine("Error: Invalid string variable");
                    variable.Print();
                }
                break;
        }

        return res;
    }
}