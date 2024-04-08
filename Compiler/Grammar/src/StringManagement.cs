using Compiler.Grammar.model;

namespace Compiler.Grammar.src;

public class StringManagement
{
    public static void AllocateString(string id, int length)
    {
        Generator.Code += $"%{id} = alloca [{length} x i8]\n";
    }
    
    public static void BitCastString(string id, int length)
    {
        Generator.Code += $"%{Generator.Reg} = bitcast [{length} x i8]* %{id} to i8*\n";
        Generator.Reg++;
    }
    
    public static void CreateConstantString(string id, string value)
    {
        var length = value.Length + 1;
        Generator.Header += $"@str.{id} = constant [{length} x i8] c\"{value}\\00\"\n";
        AllocateString(id, length);
        BitCastString(id, length);
        Generator.Code +=
            $"call void @llvm.memcpy.p0i8.p0i8.i64(i8* align 1 %{Generator.Reg - 1}, i8* align 1 getelementptr inbounds ([{length} x i8], [{length} x i8]* @str.{id}, i32 0, i32 0), i64 {length}, i1 false)\n";
    }
    
    public static void LoadString(string id, int length)
    {
        Generator.Code += $"%{Generator.Reg} = getelementptr inbounds [{length} x i8], [{length} x i8]* %{id}, i64 0, i64 0\n";
        Generator.Reg++;
    }
    
    public static void PrintString(string id, int length)
    {
        Generator.Code +=
            $"%{Generator.Reg} = call i32 (i8*, ...) @printf(i8* getelementptr inbounds ([{length} x i8], [{length} x i8]* {IoTypes.WRITE_STRING.Name}, i64 0, i64 0), i8* %{Generator.Reg - 1})\n";
        Generator.Reg++;
    }
    
    
}