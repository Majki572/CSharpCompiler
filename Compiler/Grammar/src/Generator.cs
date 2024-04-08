using Compiler.Grammar.model;

namespace Compiler.Grammar.src;

public class Generator : IGeneratorActions
{
    public static string Header = "";
    public static string Code = "";
    public static int Reg = 1;

    public void Printf(string id, Variable variable)
    {
        ReadWriteActions.Printf(id, variable);
    }

    public void Scanf(string id, VariableType type)
    {
        ReadWriteActions.Scanf(id, type);
    }

    public void Allocate(string id, Variable variable)
    {
        MemoryManagement.Allocate(id, variable);
    }

    public void Store(string id, Variable variable)
    {
        MemoryManagement.Store(id, variable);
    }

    public void Load(Variable variable)
    {
        MemoryManagement.Load(variable);
    }

    public void Add(string val1, string val2, VariableType type)
    {
        CalcOperations.Add(val1, val2, type);
    }

    public void Sub(string val1, string val2, VariableType type)
    {
        CalcOperations.Sub(val1, val2, type);
    }

    public void Mul(string val1, string val2, VariableType type)
    {
        CalcOperations.Mul(val1, val2, type);
    }

    public void Div(string val1, string val2, VariableType type)
    {
        CalcOperations.Div(val1, val2, type);
    }

    public void AllocateString(string id, int length)
    {
        StringManagement.AllocateString(id, length);
    }

    public void BitCastString(string id, int length)
    {
        StringManagement.BitCastString(id, length);
    }

    public void CreateConstantString(string id, string value)
    {
        StringManagement.CreateConstantString(id, value);
    }

    public void LoadString(string id, int length)
    {
        StringManagement.LoadString(id, length);
    }

    public void PrintString(string id, int length)
    {
        StringManagement.PrintString(id, length);
    }

    public string GenerateCode()
    {
        var code = "";
        code += "declare i32 @printf(i8*, ...)\n";
        code += "declare i32 @__isoc99_scanf(i8*, ...)\n";
        code += $"{IoTypes.READ_INT.Name} = {IoTypes.READ_INT.Import}\n";
        code += $"{IoTypes.READ_FLOAT.Name} = {IoTypes.READ_FLOAT.Import}\n";
        code += $"{IoTypes.WRITE_INT.Name} = {IoTypes.WRITE_INT.Import}\n";
        code += $"{IoTypes.WRITE_FLOAT.Name} = {IoTypes.WRITE_FLOAT.Import}\n";
        code += $"{IoTypes.WRITE_STRING.Name} = {IoTypes.WRITE_STRING.Import}\n";
        code += Header;
        code += "define dso_local i32 @main() #0 {\n";
        code += Code;
        code += "ret i32 0\n}\n";
        return code;
    }
}