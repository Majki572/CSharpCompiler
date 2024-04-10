namespace Compiler.Grammar.src;

public static class MemoryManagement
{
    public static void Allocate(string id, Variable variable)
    {
        if (variable.Type == VariableType.INT)
        {
            Generator.Code += $"%{id} = alloca i32\n";
        }
        else if (variable.Type == VariableType.FLOAT)
        {
            Generator.Code += $"%{id} = alloca float\n";
        }
        else if (variable.Type == VariableType.STRING)
        {
            Console.WriteLine(variable.Type);
            var str = (StringVariable)variable;
            Generator.Code += $"%{id} = alloca [{str.Length + 1} x i8]\n";
        }
    }

    public static void Store(string id, Variable variable)
    {
        if (variable.Type == VariableType.INT)
        {
            Generator.Code += $"store i32 {variable.Name}, i32* %{id}, align 4\n";
        }
        else if (variable.Type == VariableType.FLOAT)
        {
            Generator.Code += $"store float {variable.Name}, float* %{id}, align 4\n";
        }
        else if (variable.Type == VariableType.STRING)
        {
            Generator.Code += $"store i8* %{Generator.Reg - 1}, i8** %{id}\n";
        }
    }

    public static void Load(Variable variable)
    {
        if (variable.Type == VariableType.INT)
        {
            Generator.Code += $"%{Generator.Reg} = load i32, i32* {variable.Name}, align 4\n";
            Generator.Reg++;
        }
        else if (variable.Type == VariableType.FLOAT)
        {
            Generator.Code += $"%{Generator.Reg} = load float, float* {variable.Name}, align 4\n";
            Generator.Reg++;
        }
        else if (variable.Type == VariableType.STRING)
        {
            var length = ((StringVariable)variable).Length;
            StringManagement.LoadString(variable.Name, length);
        }
    }
}