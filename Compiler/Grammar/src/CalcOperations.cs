namespace Compiler.Grammar.src;

public class CalcOperations
{
    public static void Add(string val1, string val2, VariableType Type)
    {
        if (Type == VariableType.INT)
        {
            Generator.Code += "%" + Generator.Reg + " = add i32 " + val1 + ", " + val2 + "\n";
            Generator.Reg++;
        }
        else if (Type == VariableType.FLOAT)
        {
            Generator.Code += "%" + Generator.Reg + " = fadd float " + val1 + ", " + val2 + "\n";
            Generator.Reg++;
        }
        else
        {
            throw new Exception("Invalid Type for add operation");
        }
    }

    public static void Sub(string val1, string val2, VariableType Type)
    {
        if (Type == VariableType.INT)
        {
            Generator.Code += "%" + Generator.Reg + " = sub i32 " + val1 + ", " + val2 + "\n";
            Generator.Reg++;
        }
        else if (Type == VariableType.FLOAT)
        {
            Generator.Code += "%" + Generator.Reg + " = fsub float " + val1 + ", " + val2 + "\n";
            Generator.Reg++;
        }
        else
        {
            throw new Exception("Invalid Type for sub operation");
        }
    }

    public static void Mul(string val1, string val2, VariableType Type)
    {
        if (Type == VariableType.INT)
        {
            Generator.Code += "%" + Generator.Reg + " = mul i32 " + val1 + ", " + val2 + "\n";
            Generator.Reg++;
        }
        else if (Type == VariableType.FLOAT)
        {
            Generator.Code += "%" + Generator.Reg + " = fmul float " + val1 + ", " + val2 + "\n";
            Generator.Reg++;
        }
        else
        {
            throw new Exception("Invalid Type for mul operation");
        }
    }

    public static void Div(string val1, string val2, VariableType Type)
    {
        if (Type == VariableType.INT)
        {
            Generator.Code += "%" + Generator.Reg + " = sdiv i32 " + val1 + ", " + val2 + "\n";
            Generator.Reg++;
        }
        else if (Type == VariableType.FLOAT)
        {
            Generator.Code += "%" + Generator.Reg + " = fdiv float " + val1 + ", " + val2 + "\n";
            Generator.Reg++;
        }
        else
        {
            throw new Exception("Invalid Type for div operation");
        }
    }
}