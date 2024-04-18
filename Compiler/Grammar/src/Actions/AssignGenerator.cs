using Compiler.Grammar.model;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src.Actions;

public class AssignGenerator
{
    public static string Assign(Variable variable, Variable newVariable)
    {
        var res = "";
        switch (variable.Type) 
        {
            case VariableType.SHORT:
                res += ShortGenerator.AssignShort(variable.GetId(), newVariable.GetId());
                break;
            case VariableType.INT:
                res += IntegerGenerator.AssignInteger(variable.GetId(), newVariable.GetId());
                break;
            case VariableType.LOGNLONG:
                res += LongGenerator.AssignLong(variable.GetId(), newVariable.GetId());
                break;
            case VariableType.FLOAT:
                res += FloatGenerator.AssignFloat(variable.GetId(), newVariable.GetId());
                break;
            case VariableType.DOUBLE:
                res += DoubleGenerator.AssignDouble(variable.GetId(), newVariable.GetId());
                break;
            case VariableType.BOOL:
                res += BoolGenerator.AssignBool(variable.GetId(), newVariable.GetId());
                break;
            case VariableType.STRING or VariableType.STRING_CONST:
                if (variable is StringVariable stringVariable && newVariable is StringVariable stringVariable2)
                {
                    res += StringGenerator.AllocateStringSize(stringVariable.GetId(), stringVariable2.Length);
                    res += StringGenerator.LoadString(stringVariable.GetId());
                    if (stringVariable2.Type == VariableType.STRING_CONST)
                    {
                        res += StringGenerator.AssignConstantString(Generator.GetReg(1), stringVariable2.GetId(), stringVariable2.Length);
                    }
                    else
                    {
                        res += StringGenerator.AssignString(Generator.GetReg(1), stringVariable2.GetId());
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