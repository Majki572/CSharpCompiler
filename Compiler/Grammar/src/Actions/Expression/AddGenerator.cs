using Compiler.Grammar.model;
using Compiler.Grammar.src.Variables;

namespace Compiler.Grammar.src.Actions.Expression;

public class AddGenerator
{
    public static string Add(Variable var1, Variable var2)
    {
        var res = "";
        switch (var1.Type) 
        {
            case VariableType.SHORT:
                res += ShortGenerator.AddShort(var1.GetId(), var2.GetId());
                break;
            case VariableType.INT:
                res += IntegerGenerator.AddInteger(var1.GetId(), var2.GetId());
                break;
            case VariableType.LOGNLONG:
                res += LongGenerator.AddLong(var1.GetId(), var2.GetId());
                break;
            case VariableType.FLOAT:
                res += FloatGenerator.AddFloat(var1.GetId(), var2.GetId());
                break;
            case VariableType.DOUBLE:
                res += DoubleGenerator.AddDouble(var1.GetId(), var2.GetId());
                break;
            case VariableType.STRING or VariableType.STRING_CONST:
                if (var1 is StringVariable strVar1 && var2 is StringVariable strVar2)
                {
                    res += StringGenerator.AllocateString(Generator.GetReg());
                    Generator.Reg++;
                    res += StringGenerator.AllocateStringSize(Generator.GetReg(1), strVar1.Length + strVar2.Length);

                    var strId1 = strVar1.GetId();
                    if (strVar1.Type == VariableType.STRING_CONST)
                    {
                        strId1 = StringGenerator.GetConstString(strVar1);
                    }
                    res += StringGenerator.AddString(Generator.GetReg(1), strId1);
                    
                    var strId2 = strVar2.GetId();
                    if (strVar2.Type == VariableType.STRING_CONST)
                    {
                        strId2 = StringGenerator.GetConstString(strVar2);
                    }
                    res += StringGenerator.AddString(Generator.GetReg(1), strId2);
                }
                break;
        }

        return res;
    }
}