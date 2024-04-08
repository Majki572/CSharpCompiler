using Compiler.Grammar.model;

namespace Compiler.Grammar.src;

public abstract class ReadWriteActions
{
    public static void Printf(String id, Variable variable)
    {
        if (variable.Type == VariableType.INT)
        {
            Generator.Code +=
                $"%{Generator.Reg} = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* {IoTypes.WRITE_INT.Name}, i32 0, i32 0), i32 {id})\n";
        }
        else if (variable.Type == VariableType.FLOAT)
        {
            Generator.Code += $"%{Generator.Reg} = fpext float %{id} to double\n";
            Generator.Reg++;
            Generator.Code +=
                $"%{Generator.Reg} = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([4 x i8], [4 x i8]* {IoTypes.WRITE_FLOAT.Name}, i64 0, i64 0), double %{Generator.Reg - 1})\n";
        }
        else if (variable.Type == VariableType.STRING)
        {
            var length = ((StringVariable) variable).Length;
            StringManagement.PrintString(id, length);
        }

        Generator.Reg++;
    }

    public static void Scanf(String id, VariableType Type)
    {
        if (Type == VariableType.INT)
        {
            Generator.Code +=
                $"%{Generator.Reg} = call i32 (i8*, ...) @__isoc99_scanf(i8* noundef getelementptr inbounds ([3 x i8], [3 x i8]* {IoTypes.READ_INT.Name}, i64 0, i64 0), i32* noundef %{id})\n";
            Generator.Reg++;
        }
        else if (Type == VariableType.FLOAT)
        {
            Generator.Code +=
                $"%{Generator.Reg} = call i32 (i8*, ...) @__isoc99_scanf(i8* noundef getelementptr inbounds ([3 x i8], [3 x i8]* {IoTypes.READ_FLOAT.Name}, i64 0, i64 0), float* noundef %{id})\n";
            Generator.Reg++;
        }
    }
}